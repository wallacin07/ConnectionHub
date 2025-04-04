using Microsoft.EntityFrameworkCore;
using Api.Core;

namespace Api.AppConfiguration
{
    public static partial class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("MySql");

            services.AddDbContext<ConnectionHubContext>(options =>
                options.UseMySQL(connectionString)
            );

            return services;
        }
    }
}