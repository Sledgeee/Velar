using Microsoft.AspNetCore.Identity;
using Velar.Core.Entities.UserEntity;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using SendGrid.Helpers.Errors.Model;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.Client;
using Velar.Core.Models.Mail;
using Velar.Core.Models.User;
using Microsoft.Extensions.Options;
using Velar.Core.ViewModels;

namespace Velar.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IConfirmEmailService _confirmEmailService;
        private readonly ITemplateService _templateService;
        private readonly ClientUri _clientUri;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSenderService emailSenderService,
            IConfirmEmailService confirmEmailService,
            ITemplateService templateService,
            IOptionsMonitor<ClientUri> clientUri)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSenderService = emailSenderService;
            _confirmEmailService = confirmEmailService;
            _templateService = templateService;
            _clientUri = clientUri.CurrentValue;
        }

        public async Task LoginAsync(string email, string password, bool remember = false)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new UnauthorizedException("Incorrect email or password");
            }

            var authProps = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = remember ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddMinutes(30)
            };
            await _signInManager.SignInAsync(user, authProps);
        }

        public async Task RegistrationAsync(User user, string password, string roleName)
        {
            user.RegistrationDate = new DateTimeOffset(DateTime.UtcNow, TimeSpan.Zero);
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                StringBuilder errorMessage = new();
                foreach (var error in result.Errors)
                {
                    errorMessage.Append(error.Description.ToString() + " ");
                }
                throw new BadRequestException(errorMessage.ToString());
            }

            var findRole = await _roleManager.FindByNameAsync(roleName);

            if (findRole == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SentResetPasswordTokenAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedCode = Convert.ToBase64String(Encoding.Unicode.GetBytes(token));

            var body = await _templateService.GetTemplateHtmlAsStringAsync("Mails/ResetPassword",
                new UserTokenViewModel
                {
                    FirstName = user.FirstName,
                    BaseUri = new Uri(_clientUri.Uri),
                    ActionUri = new Uri($"{_clientUri.Uri}/auth/reset-password?uid={user.Id}&token={encodedCode}")
                });
            await _emailSenderService.SendEmailAsync(new SendMail
            {
                ToEmail = user.Email,
                Subject = "VELAR Reset Password",
                Body = body
            });
        }

        public async Task ResetPasswordAsync(ChangePassword changePassword)
        {
            var user = await _userManager.FindByIdAsync(changePassword.UserId);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            var decodedCode = _confirmEmailService.DecodeUnicodeBase64(changePassword.Code);
            var result = await _userManager.ResetPasswordAsync(user, decodedCode, changePassword.NewPassword);

            if (!result.Succeeded)
            {
                throw new BadRequestException("Wrong reset password code");
            }
        }
    }
}
