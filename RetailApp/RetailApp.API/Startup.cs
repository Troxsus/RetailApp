using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailApp.API.GrpcClients;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.MapperConfigs;
using RetailApp.API.Models.ConfigOptions;

namespace RetailApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<ServiceAddressOptions>(Configuration.GetSection("ServiceAdress"));

            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductApiProfile>();
                config.AddProfile<PaymentApiProfile>();
                config.AddProfile<OrderApiProfile>();
            });

            services.AddScoped<IOrderClient, OrderClient>();
            services.AddScoped<IPaymentClient, PaymentClient>();
            services.AddScoped<IProductClient, ProductClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
