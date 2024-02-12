using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.Application.Common.Contracts;
using PostManager.Infrastructure.Persistance;
using PostManager.Infrastructure.Persistance.Identity;

namespace PostManager.Infrastructure
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            )
        {
            services.AddDbContext<PostManagerDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            AddAuthentication(services);
            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            services.AddScoped<ITokenClaimService, TokenClaimService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PostManagerDbContext>().
                            AddUserManager<UserManager<User>>().AddSignInManager<SignInManager<User>>().
                            AddRoleManager<RoleManager<Role>>().
                            AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.`~ ";
            });
            return services;
        }
    }
}
