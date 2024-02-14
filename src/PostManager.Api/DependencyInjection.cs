using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PostManager.Api.Services;
using PostManager.Application.Common.Contracts;
using System.Text;

namespace PostManager.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUserService, UserService>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithOrigins("http://localhost:3000"));

            });
            services.AddProblemDetails();
            return services;
        }
    }
}
