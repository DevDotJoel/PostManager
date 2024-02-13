using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PostManager.Application.Common.Contracts;
using PostManager.Application.Common.Repositories;
using PostManager.Infrastructure.Persistance;
using PostManager.Infrastructure.Persistance.Identity;
using PostManager.Infrastructure.Persistance.Repositories;
using System.Text;

namespace PostManager.Infrastructure
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration
            )
        {
            services.AddDbContext<PostManagerDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddScoped<IPostRepository, PostRepository>();
            AddAuthentication(services, configuration);
            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ITokenClaimService, TokenClaimService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PostManagerDbContext>().
                            AddUserManager<UserManager<User>>().AddSignInManager<SignInManager<User>>().
                            AddRoleManager<RoleManager<Role>>().
                            AddDefaultTokenProviders();
            var jwtSettings = configuration.GetSection("JwtSettings");
            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.`~ ";
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            return services;
        }
    }
}
