using Microsoft.Extensions.DependencyInjection;
using Velar.Services.Auth;
using Velar.Services.Shop;
using Velar.Services.User;

namespace Velar.Services
{
    public static class StartupSetup
    {
        public static void AddVelarServices(this IServiceCollection services)
        {
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}