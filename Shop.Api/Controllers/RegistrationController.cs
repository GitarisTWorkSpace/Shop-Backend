using Microsoft.AspNetCore.Mvc;
using Shop.Api.Contracts.User;
using Shop.Core.Stores;
using Shop.Core.Models;
using Shop.Application.Services;

namespace Shop.Api.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult> Registration([FromBody] RegistrationUserRequest user)
        {
            var result = await _registrationService.RegisterUser(user.name, user.surname, user.email, user.phoneNumber);
            if (!result.Status)
                return BadRequest(result.Error);

            return Ok(result.Error);
        }
    }
}
