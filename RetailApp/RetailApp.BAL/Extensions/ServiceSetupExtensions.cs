using Microsoft.Extensions.DependencyInjection;
using RetailApp.Data.Extensions;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.BAL.Providers;

namespace RetailApp.BAL.Extensions
{
    public static class ServiceSetupExtensions
    {
        public static void AddBalDependencies(this IServiceCollection services)
        {
            services.AddDataDependencies();

            services.AddScoped<IOrderProvider, OrderProvider>();
            services.AddScoped<IPaymentProvider, PaymentProvider>();
            services.AddScoped<IProductProvider, ProductProvider>();
        }
    }
}
