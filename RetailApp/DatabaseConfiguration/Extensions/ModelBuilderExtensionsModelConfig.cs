using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;

namespace RetailApp.Data.Extensions
{
    public static class ModelBuilderExtensionsModelConfig
    {
        public static void ConfigureForeignKeys(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(x => x.Payments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity(
                    "ProductOrder",
                    l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.Id)),
                    r => r.HasOne(typeof(Order)).WithMany().HasForeignKey("OrderId").HasPrincipalKey(nameof(Order.Id)),
                    j => j.HasKey("ProductId", "OrderId")
                 );

            builder.Entity<Order>()
                .HasOne(x => x.Payment)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
