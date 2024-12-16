using BusinessLogic.Authorization;
using BusinessLogic.Models.Accounts;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;

namespace MnogoLibAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        private void setTokenCoockie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authencticate(AuthenticateRequest model)
        {
            var resposne = await _accountService.Authenticate(model, ipAddress());
            setTokenCoockie(resposne.RefreshToken);
            return Ok(resposne);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenticateResponse>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var resposne = await _accountService.RefreshToken(refreshToken, ipAddress());
            setTokenCoockie(resposne.RefreshToken);
            return Ok(resposne);
        }

        [AllowAnonymous]
        [HttpPost("revoke-token")]
        public async Task<ActionResult<AuthenticateResponse>> RevokeToken(RevokeTokenRequest model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            if (!User.OwnsToken(token) && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });

            await _accountService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<AuthenticateResponse>> Register(RegisterRequest model)
        {
            await _accountService.Register(model, Request.Headers["origin"]);
            return Ok(new { message = "Registration successful, please check your email" });
        }

        [AllowAnonymous]
        [HttpPost("verify-email")]
        public async Task<ActionResult<AuthenticateResponse>> VerifyEmail(VerifyEmailRequest model)
        {
            await _accountService.VerifyEmail(model.Token);
            return Ok(new { message = "Verification successful, you can now login" });
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<ActionResult<AuthenticateResponse>> ForgotPassword(ForgotPasswordRequest model)
        {
            await _accountService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok(new { message = "Please check your email for password reset instuctions" });
        }

        [AllowAnonymous]
        [HttpPost("validate-reset-token")]
        public async Task<ActionResult<AuthenticateResponse>> ValidateResetToken(ValidateResetTokenRequest model)
        {
            await _accountService.ValidateResetToken(model);
            return Ok(new { message = "Token is valid" });
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<ActionResult<AuthenticateResponse>> ResetPassword(ResetPasswordRequest model)
        {
            await _accountService.ResetPassword(model);
            return Ok(new { message = "Password reset successful, you can now login" });
        }

        [Authorize(3)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAll()
        {
            var accounts = await _accountService.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetById(int id)
        {
            if (id != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });

            var accounts = await _accountService.GetById(id);
            return Ok(accounts);
        }

        [Authorize(3)]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> Create(CreateRequest model)
        {
            var accounts = await _accountService.Create(model);
            return Ok(accounts);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AccountResponse>> Update(int id, UpdateRequest model)
        {
            if (id != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });

            if (User.IdRole != 3)
                model.Role = 1;

            var accounts = await _accountService.Update(id, model);
            return Ok(accounts);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AccountResponse>> Delete(int id)
        {
            if (id != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });

            await _accountService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }
    }
}