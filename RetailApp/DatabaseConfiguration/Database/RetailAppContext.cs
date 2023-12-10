using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Extensions;
using RetailApp.Data.Models;

namespace RetailApp.Data.Database
{
    public class RetailAppContext : DbContext
    {
        public RetailAppContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureForeignKeys();
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
