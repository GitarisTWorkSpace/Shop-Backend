using Microsoft.AspNetCore.Mvc;
using Shop.Api.Contracts.User;

namespace Shop.Api.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Registration([FromBody] RegistrationUserRequest user)
        {
            return Ok();
        }
    }
}
