using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailApp.Data.Database;
using RetailApp.Data.Providers.Interfaces;
using RetailApp.Data.Providers;

namespace RetailApp.Data.Extensions
{
    public static class DataServiceSetupExtensions
    {
        public static void AddDataDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RetailAppContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDbRepositoryProvider, DbRepositoryProvider>();
        }
    }
}
