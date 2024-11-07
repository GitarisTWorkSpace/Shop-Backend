using Shop.Core.Models;
using Shop.Core.Stores;

namespace Shop.Application.Services
{
    public class RegistrationService
    {
        private readonly IUserStore _userStore;

        public RegistrationService(IUserStore userStore)
        {
            _userStore = userStore;
        }

        public async Task<ServiceResult> RegisterUser(string name, string surname, string email, string phoneNumber)
        {
            User newUser = new User();

            var nameValidation = NameValidation(name);

            if (!nameValidation.Status) return nameValidation;

            var surnameValidation = SurnameValidation(surname);

            if (!surnameValidation.Status) return surnameValidation;

            var emailValidation = EmailValidation(email);

            if (!emailValidation.Status) return emailValidation;

            var phoneNumberValidation = PhoneNumberValidation(phoneNumber);

            if (!phoneNumberValidation.Status) return phoneNumberValidation;

            newUser.Name = name;
            newUser.Surname = surname;

            newUser.Email = email;
            newUser.PhoneNumber = phoneNumber;

            long resunt = await _userStore.CreateUser(newUser);

            if (resunt != 1)
                return new ServiceResult(false, "Пользователь не зарегистрированный попробуйте еще раз");

            return new ServiceResult(true, "Пользователь создан");
        }

        private ServiceResult NameValidation(string name)
        {
            if (name.Length == 0)
                return new ServiceResult(false, "Имя не может быть пустым");

            if (name.Length > 256)
                return new ServiceResult(false, "Имя слишком длинное");

            return new ServiceResult(true, "Имя валидно");
        }

        private ServiceResult SurnameValidation(string surname) 
        {
            if (surname != null && surname.Length > 256)
                return new ServiceResult(false, "Фамилия слишком длинная");

            return new ServiceResult(true, "Фамилия валидна");
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

        private ServiceResult PhoneNumberValidation(string phoneNumber) 
        {
            if (phoneNumber != null && phoneNumber.Length < 11)
                return new ServiceResult(false, "Номер телефона слишком короткий");

            if (phoneNumber != null && phoneNumber.Length > 11)
                return new ServiceResult(false, "Номер телефона слишком длинный");

            foreach (char num in phoneNumber)
            {
                if (char.IsLetter(num))
                    return new ServiceResult(false, "Номер телефона содержит символы");
            }

            return new ServiceResult(true, "Телефон валиден");
        }
    }
}
