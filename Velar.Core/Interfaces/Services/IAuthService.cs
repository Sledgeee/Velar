using Velar.Core.Entities.UserEntity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Velar.Core.Models.User;

namespace Velar.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegistrationAsync(User user, string password, string roleName);
        Task LoginAsync(string email, string password, bool remember);
        Task LogoutAsync();
        Task SentResetPasswordTokenAsync(string userEmail);
        Task ResetPasswordAsync(ChangePassword changePassword);
    }
}
