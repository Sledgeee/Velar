using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Velar.Core.Interfaces.Services;
using Velar.Core.Models.Client;
using Velar.Core.Models.Mail;
using Velar.Core.Services;

namespace Velar.Core
{
    public static class StartupSetup
    {
        public static void AddVelarServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IConfirmEmailService, ConfirmEmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IFileService, FileService>();
        }

        public static void ConfigureVelarSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendGridSettings>(configuration.GetSection("SendGridSettings"));
            services.Configure<ClientUri>(configuration.GetSection("ClientSettings"));
        }
    }
}
