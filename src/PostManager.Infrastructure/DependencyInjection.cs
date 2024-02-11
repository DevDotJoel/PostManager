using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.Infrastructure.Persistance;

namespace PostManager.Infrastructure
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddDbContext<PostManagerDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            return services;
        }
    }
}
