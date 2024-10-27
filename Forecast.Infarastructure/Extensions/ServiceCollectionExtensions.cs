using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Forecast.Infarastructure.Data;

namespace Forecast.Infarastructure.Extensions
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
