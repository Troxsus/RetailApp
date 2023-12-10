using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailApp.Data.Database;
using RetailApp.Data.Repository.Interfaces;
using RetailApp.Data.Repository;

namespace RetailApp.Data.Extensions
{
    public static class DataServiceSetupExtensions
    {
        public static void AddDataDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RetailAppContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IDbContextRepository<>), typeof(DbContextRepository<>));
        }
    }
}
