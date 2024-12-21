using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using BusinessLogic.Models.Accounts;
using Domain.Entites;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Security.Cryptography;

namespace BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountService(
            IRepositoryWrapper repositoryWrapper,
            IJwtUtils jwtUtils,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _repositoryWrapper = repositoryWrapper;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        private void reamoveOldRefreshTokens(User account)
        {
            account.RefreshTokens.RemoveAll(x =>
            !x.isActive &&
            x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = await _repositoryWrapper.User.GetByEmailWithToken(model.Email);

            if (account == null || !account.IsVerified || !BCrypt.Net.BCrypt.Verify(model.Password, account.PasswordUser))
                throw new AppException("Email or password is incorrect");

            var jwtToken = _jwtUtils.GenerateJwtToken(account);
            var refreshToken = await _jwtUtils.GenerateRefreshToken(ipAddress);
            account.RefreshTokens.Add(refreshToken);

            reamoveOldRefreshTokens(account);

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;
        }

        public async Task<AccountResponse> Create(CreateRequest model)
        {
            if ((await _repositoryWrapper.User.FindByCondition(x => x.EmailUser == model.Email)).Count > 0)
                throw new AppException($"Email '{model.Email}' is already registred");
            var account = _mapper.Map<User>(model);
            account.CreatedTime = DateTime.UtcNow;
            account.Verified = DateTime.UtcNow;

            account.PasswordUser = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();

            return _mapper.Map<AccountResponse>(account);
        }

        public async Task Delete(int id)
        {
            var account = await getAccount(id);
            await _repositoryWrapper.User.Delete(account);
            await _repositoryWrapper.Save();
        }

        private async Task<string> generateResetToken()
        {
            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            var tokenIsUnique = (await _repositoryWrapper.User.FindByCondition(x => x.ResetToken == token)).Count == 0;
            if (!tokenIsUnique)
                return await generateResetToken();
            return token;
        }


        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = (await _repositoryWrapper.User.FindByCondition(x => x.EmailUser == model.Email)).FirstOrDefault();

            if (account == null) return;

            account.ResetToken = await generateResetToken();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();
            _emailService.Send(account.EmailUser, "Сброс пароля", $"Пачуля не может сказать твой пароль, но может дать тебе новый\nДля сброса вашего пароля введите этот токен:\n{account.ResetToken}");
        }

        public async Task<IEnumerable<AccountResponse>> GetAll()
        {
            var account = await _repositoryWrapper.User.FindAll();
            return _mapper.Map<IList<AccountResponse>>(account);
        }

        public async Task<AccountResponse> GetById(int id)
        {
            var account = await getAccount(id);
            return _mapper.Map<AccountResponse>(account);
        }

        private async Task<User> getAccountByRefreshToken(string token)
        {
            var account = (await _repositoryWrapper.User.FindByCondition(u => u.RefreshTokens.Any(t => t.Token == token))).SingleOrDefault();
            if (account == null) throw new AppException("Invalid token");
            account = await _repositoryWrapper.User.GetByIdWithToken(account.IdUser);
            return account;
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        private async Task<RefreshToken> rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = await _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void revokeDescendantRefreshToken(RefreshToken refreshToken, User account, string ipAddress, string reason)
        {
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = account.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.isActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshToken(childToken, account, ipAddress, reason);
            }
        }

        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var account = await getAccountByRefreshToken(token);
            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                revokeDescendantRefreshToken(refreshToken, account, ipAddress, $"Attempted reuse of revoked acestor token: {token}");
                await _repositoryWrapper.User.Update(account);
                await _repositoryWrapper.Save();
            }

            if (!refreshToken.isActive)
                throw new AppException("Invalid token");

            var newRefreshToken = await rotateRefreshToken(refreshToken, ipAddress);
            account.RefreshTokens.Add(newRefreshToken);

            reamoveOldRefreshTokens(account);

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();

            var jwtToken = _jwtUtils.GenerateJwtToken(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;
        }

        private async Task<string> generateVerificationToken()
        {
            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

            var tokenIsUnique = (await _repositoryWrapper.User.FindByCondition(x => x.VerificationToken == token)).Count == 0;
            if (!tokenIsUnique)
                return await generateVerificationToken();

            return token;
        }

        public async Task Register(RegisterRequest model, string origin)
        {
            if ((await _repositoryWrapper.User.FindByCondition(x => x.EmailUser == model.EmailUser)).Count > 0)
                return;

            var account = _mapper.Map<User>(model);

            var isFitstAccount = (await _repositoryWrapper.User.FindAll()).Count == 0;
            // 1 - User, 2 - Moder, 3 - Admin
            account.IdRole = isFitstAccount ? 3 : 1;
            account.CreatedTime = DateTime.UtcNow;
            account.Verified = DateTime.UtcNow;
            account.VerificationToken = await generateVerificationToken();

            account.PasswordUser = BCrypt.Net.BCrypt.HashPassword(model.PasswordUser);

            await _repositoryWrapper.User.Create(account);
            await _repositoryWrapper.Save();
            _emailService.Send(account.EmailUser, "Подтвердите почту", $"Если вы не введете этот токен, то я вам ничего не сделаю:\n{account.VerificationToken}");
        }

        private async Task<User> getAccountByResetToken(string token)
        {
            var account = (await _repositoryWrapper.User.FindByCondition(x =>
                x.ResetToken == token && x.ResetTokenExpires > DateTime.UtcNow)).SingleOrDefault();
            if (account == null) throw new AppException("Invalid token");
            return account;
        }

        public async Task ResetPassword(ResetPasswordRequest model)
        {
            var account = await getAccountByResetToken(model.Token);

            account.PasswordUser = BCrypt.Net.BCrypt.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();
        }

        public async Task RevokeToken(string token, string ipAddress)
        {
            var account = await getAccountByRefreshToken(token);
            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.isActive)
                throw new AppException("Invalid token");

            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();
        }

        private async Task<User> getAccount(int id)
        {
            var account = (await _repositoryWrapper.User.FindByCondition(x => x.IdUser == id)).FirstOrDefault();
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }
        public async Task<AccountResponse> Update(int id, UpdateRequest model)
        {
            var account = await getAccount(id);

            if (account.EmailUser != model.Email && (await _repositoryWrapper.User.FindByCondition(x => x.EmailUser == model.Email)).Count > 0)
                throw new AppException($"Email '{model.Email}' is already registred");

            if (!string.IsNullOrEmpty(model.Password))
                account.PasswordUser = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _mapper.Map(model, account);
            account.Updated = DateTime.UtcNow;
            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();

            return _mapper.Map<AccountResponse>(account);
        }

        public async Task ValidateResetToken(ValidateResetTokenRequest model)
        {
            await getAccountByResetToken(model.Token);
        }

        public async Task VerifyEmail(string token)
        {
            var account = (await _repositoryWrapper.User.FindByCondition(x => x.VerificationToken == token)).FirstOrDefault();

            if (account == null)
                throw new Exception("Verification failed");

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            await _repositoryWrapper.User.Update(account);
            await _repositoryWrapper.Save();
        }

    }
}