using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Database.ModelConfiguration;
using RetailApp.Data.Extensions;

namespace RetailApp.Data.Database
{
    public class RetailAppContext : DbContext
    {
        public RetailAppContext()
        { }

        public RetailAppContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddPaymentConfiguration();
            modelBuilder.AddProductConfiguration();
            modelBuilder.AddOrderConfiguration();
            modelBuilder.AddUserConfiguration();

            modelBuilder.SeedData();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
