using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Velar.Core.Models.Mail;

namespace Velar.Core.Interfaces.Services
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(SendMail mail);

        Task<Response> SendEmailAsync(SendGridMessage message);
    }
}
