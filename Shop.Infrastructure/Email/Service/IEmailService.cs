using Shop.Core;

namespace Shop.Infrastructure.Email.Service
{
    public interface IEmailService
    {
        public ServiceResult SendEmail(string userName, string userEmail, string message);
    }
}
