using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.Mail;

namespace Velar.Core.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SendGridSettings _mailSettings;
        public EmailSenderService(IOptionsMonitor<SendGridSettings> options)
        {
            _mailSettings = options.CurrentValue;
        }

        public async Task SendEmailAsync(SendMail mail)
        {
            var client = new SendGridClient(_mailSettings.ApiKey);

            await client.SendEmailAsync(CreateMessage(mail));
        }

        public async Task<Response> SendEmailAsync(SendGridMessage message)
        {
            var client = new SendGridClient(_mailSettings.ApiKey);

            return await client.SendEmailAsync(message);
        }

        private SendGridMessage CreateMessage(SendMail mail)
        {
            SendGridMessage message = new()
            {
                From = new EmailAddress(_mailSettings.Email, _mailSettings.DisplayName),
                Subject = mail.Subject,
                HtmlContent = mail.Body,
            };
            message.AddTo(mail.ToEmail);

            return message;
        }
    }
}
