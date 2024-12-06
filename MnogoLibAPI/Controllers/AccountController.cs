using MnogoLibAPI.Authorization;
using BusinessLogic.Authorization;
using BusinessLogic.Models.Accounts;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
                HttpOnly = true;
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

        [Authorization.AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authencticate(AuthenticateRequest model)
        {
            var resposne = await _accountService.Authenticate(model, ipAddress());
            setTokenCoockie(resposne.RefreshToken);
            return Ok(resposne);
        }

        [Authorization.AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenticateResponse>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var resposne = await _accountService.RefreshToken(refreshToken, ipAddress());
            setTokenCoockie(resposne.RefreshToken);
            return Ok(resposne);
        }
        
        [Authorization.AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthenticateResponse>> RevokeToken(RevokeTokenRequest model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new {message = "Token is required"});

            if (!User.OwnsToken(token) && User.IdRole != 3)
                return Unauthorized(new {message = "Unauthorized"});

            await _accountService.RevokeToken(token, ipAddress());
            return Ok(new {message = "Token revoked"});
        }

    }
}