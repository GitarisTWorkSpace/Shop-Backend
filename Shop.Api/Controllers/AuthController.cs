using Microsoft.AspNetCore.Mvc;
using Shop.Api.Contracts.User;
using Shop.Application.Services;
using System.Net;

namespace Shop.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginService _loginService;

        public AuthController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [Route("login/")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var result = await _loginService.LoginUser(loginRequest.email);

            if (!result.Status) 
                return BadRequest(result.Error);

            return Ok(result.Error);
        }

        [Route("confirm/")]
        [HttpPost]
        public async Task<ActionResult> ConfirmLogin(UserCodeConfirmRequest confirmRequest)
        {
            var result = await _loginService.ConfirmLogin(confirmRequest.email, confirmRequest.code);

            if (!result.Status) 
                return BadRequest(result.Error);

            Response.Cookies.Append("favourite-displace", result.Error);

            return Ok("пользователь аутентифицирован");
        }
    }
}
