using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Forecast.Infrastructure.Data;

namespace Forecast.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddForecastDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ForecastDbContext>(options =>
                options.UseSqlite(connectionString));
            return services;
        }
    }
}
