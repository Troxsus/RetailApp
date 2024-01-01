using Microsoft.Extensions.DependencyInjection;
using RetailApp.Data.Database;

namespace RetailApp.Data.Extensions
{
    public static class DataServiceSetupExtensions
    {
        public static void AddDataDependencies(this IServiceCollection services)
        {
            services.AddDbContext<RetailAppContext>(options => { });
        }
    }
}
