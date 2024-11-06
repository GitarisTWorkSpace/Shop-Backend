using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Contracts.User;
using Shop.Core.Stores;
using Shop.Core.Models;

namespace Shop.Api.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserStore _userStore;

        public RegistrationController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        [HttpPost]
        public async Task<ActionResult> Registration([FromBody] RegistrationUserRequest user)
        {
            User newUser = new User();

            if (user == null)
                return BadRequest("Пустые данные");

            if (user.name.Length == 0)
                return BadRequest("Имя не может быть пустым");

            if (user.name.Length > 256)
                return BadRequest("Имя слишком длинное");

            if (user.surname != null && user.surname.Length > 256)
                return BadRequest("Фамилия слишком длинная");

            if (user.email.Length == 0)
                return BadRequest("Почта не может быть пустой");

            if (user.email.Length > 256)
                return BadRequest("Почта слишком длинное");            

            if (user.email.Split('@').Length == 1)
                return BadRequest("Почта не валидна, добавте '@'");

            if (user.email.Split('@').Length > 2)
                return BadRequest("Почта не валидна, лишние '@'");

            string emailString = user.email.Split('@')[1];

            if (emailString.Split('.').Length == 1)
                return BadRequest("Почта не валидна, добавте домен");

            if (emailString.Split('.').Length > 2)
                return BadRequest("Почта не валидна, лишние точки");

            string emailDomenString = emailString.Split(".")[1];

            if (emailDomenString.Length == 0)
                return BadRequest("Почта не валидна, нет домена");

            if (user.phoneNumber != null && user.phoneNumber.Length < 11)
                return BadRequest("Номер телефона слишком короткий");

            if (user.phoneNumber != null && user.phoneNumber.Length > 11)
                return BadRequest("Номер телефона слишком длинный");

            foreach(char num in user.phoneNumber)
            {
                if (char.IsLetter(num))
                    return BadRequest("Номер телефона содержит символы");
            }            

            newUser.Name = user.name;
            newUser.Surname = user.surname;

            newUser.Email = user.email;
            newUser.PhoneNumber = user.phoneNumber;

            long resunt = await _userStore.CreateUser(newUser);

            if(resunt != 1)
                return BadRequest("Пользователь не зарегистрированный попробуйте еще раз");

            return Ok();
        }
    }
}
