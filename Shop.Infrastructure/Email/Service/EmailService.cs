using MailKit.Net.Smtp;
using Shop.Core;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Shop.Infrastructure.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _options;

        public EmailService(IOptions<EmailOptions> options)
        {
            _options = options.Value;
        }

        public ServiceResult SendEmail(string userName, string userEmail, string message)
        {
            try
            {
                MimeMessage mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_options.Name, _options.Address));
                mimeMessage.To.Add(new MailboxAddress(userName, userEmail));
                mimeMessage.Subject = "Код для авторизации";
                string bodyHtmlText = $"<div>Ваш код для авторизации <b>{message}</b> </div>";
                mimeMessage.Body = new BodyBuilder() { HtmlBody = bodyHtmlText }.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(_options.Host, _options.Port, true);
                    client.Authenticate(_options.Address, _options.Password);
                    client.Send(mimeMessage);

                    client.Disconnect(true);

                    return new ServiceResult(true, "сообщение отправлено");
                }                    
            }
            catch (Exception e)
            {
                return new ServiceResult(false, e.Message);
            }
        }
    }
}
