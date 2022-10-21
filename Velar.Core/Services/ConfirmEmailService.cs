using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Velar.Core.Entities.UserEntity;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.Client;
using Velar.Core.Models.Mail;
using Velar.Core.ViewModels;

namespace Velar.Core.Services
{
    public class ConfirmEmailService : IConfirmEmailService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSenderService _emailService;
        private readonly ITemplateService _templateService;
        private readonly ClientUri _clientUri;

        public ConfirmEmailService(UserManager<User> userManager,
            IEmailSenderService emailSender,
            ITemplateService templateService,
            IOptionsMonitor<ClientUri> clientUri)
        {
            _userManager = userManager;
            _emailService = emailSender;
            _templateService = templateService;
            _clientUri = clientUri.CurrentValue;
        }

        public async Task SendConfirmMailAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            CheckUserAndEmailConfirmed(user);

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedCode = Convert.ToBase64String(Encoding.Unicode.GetBytes(token));

            await _emailService.SendEmailAsync(new SendMail
            {
                ToEmail = user.Email,
                Subject = "VELAR Confirm Email",
                Body = await _templateService.GetTemplateHtmlAsStringAsync("Mails/ConfirmEmail",
                    new UserTokenViewModel()
                    {
                        FirstName = user.FirstName,
                        BaseUri = new Uri(_clientUri.Uri),
                        ActionUri = new Uri($"{_clientUri.Uri}/auth/confirm-email?uid={user.Id}&token={encodedCode}")
                    })
            });

            await Task.CompletedTask;
        }

        public async Task ConfirmEmailAsync(string userId, string confirmationCode)
        {
            var user = await _userManager.FindByIdAsync(userId);

            CheckUserAndEmailConfirmed(user);

            var decodedCode = DecodeUnicodeBase64(confirmationCode);

            var result = await _userManager.ConfirmEmailAsync(user, decodedCode);

            if(!result.Succeeded)
            {
                throw new BadRequestException("Wrong confirmation code");
            }

            await _userManager.UpdateSecurityStampAsync(user);

            await Task.CompletedTask;
        }

        private void CheckUserAndEmailConfirmed(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            if (user.EmailConfirmed)
            {
                throw new BadRequestException("Email already confirmed");
            }
        }

        public string DecodeUnicodeBase64(string input)
        {
            var bytes = new Span<byte>(new byte[input.Length]);

            if(!Convert.TryFromBase64String(input, bytes, out var bytesWritten))
            {
                throw new BadRequestException("Invalid confirmation code");
            }

            return Encoding.Unicode.GetString(bytes.Slice(0, bytesWritten));
        }
    }
}
