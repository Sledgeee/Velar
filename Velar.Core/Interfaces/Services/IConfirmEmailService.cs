using System.Threading.Tasks;

namespace Velar.Core.Interfaces.Services
{
    public interface IConfirmEmailService
    {
        Task SendConfirmMailAsync(string userId);

        Task ConfirmEmailAsync(string userId, string confirmationCode);

        string DecodeUnicodeBase64(string input);
    }
}
