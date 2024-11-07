using Shop.Core.Stores;
using Shop.Core.Models;
using Shop.Infrastructure.JWT;

namespace Shop.Application.Services
{
    public class LoginService
    {
        private readonly IUserStore _userStore;
        private readonly ILoginCodeStore _loginCodeStore;
        private readonly IJwtProvider _jwtProvider;

        public LoginService(IUserStore userStore, ILoginCodeStore loginCodeStore, IJwtProvider jwtProvider) 
        {
            _userStore = userStore;
            _loginCodeStore = loginCodeStore;
            _jwtProvider = jwtProvider;
        }

        public async Task<ServiceResult> LoginUser(string email)
        {
            var emailValid = EmailValidation(email);
            
            if (!emailValid.Status) return emailValid;

            User user = await _userStore.GetByEmail(email);

            if (user == null)
                return new ServiceResult(false, "Пользователь не найден");

            // create code

            int code = await _loginCodeStore.CreateLoginCodeForUser(user.Id, GenerateCode());

            if (code == 0) 
                return new ServiceResult(false, "Код не сохранен");

            // send messadge

            return new ServiceResult(true, "Код отправлен");
        }

        public async Task<ServiceResult> ConfirmLogin(string email, string code)
        {
            var emailValid = EmailValidation(email);

            if (!emailValid.Status) return emailValid;

            User user = await _userStore.GetByEmail(email);

            if (user == null)
                return new ServiceResult(false, "Пользователь не найден");

            string accessСode = await _loginCodeStore.GetCodeByUser(user.Id);

            if (code != accessСode)
                return new ServiceResult(false, "Неверный код");

            var token = _jwtProvider.GenerateToken(user);

            return new ServiceResult(true, token);
        }

        private ServiceResult CodeValidation(string code) 
        {
            if (code.Length < 0)
                return new ServiceResult(false, "Пустой код");

            if (code.Length > 6)
                return new ServiceResult(false, "Слишком длинный код");

            if (code.Length < 6)
                return new ServiceResult(false, "Слишком короткий код");

            return new ServiceResult(true, "Код валиден");
        }

        private ServiceResult EmailValidation(string email)
        {
            if (email.Length == 0)
                return new ServiceResult(false, "Почта не может быть пустой");

            if (email.Length > 256)
                return new ServiceResult(false, "Почта слишком длинное");

            if (email.Split('@').Length == 1)
                return new ServiceResult(false, "Почта не валидна, добавте '@'");

            if (email.Split('@').Length > 2)
                return new ServiceResult(false, "Почта не валидна, лишние '@'");

            string emailString = email.Split('@')[1];

            if (emailString.Split('.').Length == 1)
                return new ServiceResult(false, "Почта не валидна, добавте домен");

            if (emailString.Split('.').Length > 2)
                return new ServiceResult(false, "Почта не валидна, лишние точки");

            string emailDomenString = emailString.Split(".")[1];

            if (emailDomenString.Length == 0)
                return new ServiceResult(false, "Почта не валидна, нет домена");

            return new ServiceResult(true, "Почта валидна");
        }

        private string GenerateCode()
        {
            int lenght = 6;
            string numbers = "123456789";

            string code = "";

            Random rnd = new Random();

            while (0 < lenght--)
            {
                code += numbers[rnd.Next(numbers.Length)];
            }

            return code;
        }
    }
}
