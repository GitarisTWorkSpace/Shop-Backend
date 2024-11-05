using Microsoft.AspNetCore.Mvc;
using Shop.Api.Contracts.User;

namespace Shop.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("login/")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest email)
        {
            return Ok();
        }

        [Route("confirm/")]
        [HttpPost]
        public async Task<ActionResult> ConfirmLogin([FromBody] UserCodeConfirmRequest code)
        {
            return Ok();
        }
    }
}
