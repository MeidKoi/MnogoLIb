using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using Domain.Entites;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MnogoLibAPI.Authorization
{
    public class jwtUtils : IJwtUtils
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly AppSettings _appSettings;

        public jwtUtils(
            IRepositoryWrapper wrapper,
            IOptions<AppSettings> appSettings)
        {
            _wrapper = wrapper;
            _appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(User account)
        {
            var tokenHangler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.IdUser.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHangler.CreateToken(tokenDescription);
            return tokenHangler.WriteToken(token);
        }

        public async Task<RefreshToken> GenerateRefreshToken(string ipAddress)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };

            var tokenIsUnique = (await _wrapper.User.FindByCondition(a => a.RefreshTokens.Any(t => t.Token == refreshToken.Token))).Count == 0;

            if (!tokenIsUnique)
                return await GenerateRefreshToken(ipAddress);

            return refreshToken;
        }

        public int? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHangler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            try
            {
                tokenHangler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                return accountId;
            }
            catch
            {
                return null;
            }
        }

    }
}