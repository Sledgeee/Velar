using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Velar.Core.Entities.UserEntity;
using Velar.Core.Interfaces.Repositories;
using Velar.Infrastructure.Context;
using Velar.Infrastructure.Repositories;

namespace Velar.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddEntityFrameworkDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VelarDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<VelarDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
