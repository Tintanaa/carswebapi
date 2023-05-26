using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Cars.Application.Interfaces;

namespace Cars.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CarsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<ICarsDbContext>(provider =>
                provider.GetService<CarsDbContext>());
            return services;
        }
    }
}
