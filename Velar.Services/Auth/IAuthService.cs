using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Velar.Services.Auth.Models;

namespace Velar.Services.Auth
{
    public interface IAuthService
    {
        Task RegistrationAsync(User user, string password, string roleName);
        Task<UserAutorizationDTO> LoginAsync(string email, string password);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserAutorizationDTO userTokensDTO);
        Task<UserAutorizationDTO> LoginTwoStepAsync(UserTwoFactorDTO twoFactorDTO);
        Task SentResetPasswordTokenAsync(string userEmail);
        Task ResetPasswordAsync(UserChangePasswordDTO userChangePasswordDTO);
        Task<UserAuthResponseDTO> ExternalLoginAsync(UserExternalAuthDTO authDTO);
    }
}