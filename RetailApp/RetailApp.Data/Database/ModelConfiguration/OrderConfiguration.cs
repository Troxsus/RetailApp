using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;

namespace RetailApp.Data.Database.ModelConfiguration
{
    internal static class OrderConfiguration
    {
        public static void AddOrderConfiguration(this ModelBuilder builder)
        {
            builder
                .Entity<Order>()
                .ToTable("orders");

            builder
                .Entity<Order>()
                .HasKey(p => p.OrderId);

            builder
                .Entity<Order>()
                .Property(p => p.TotalPrice)
                .HasColumnType("float")
                .HasColumnName("order_totalprice")
                .IsRequired();
            
            builder
                .Entity<Order>()
                .Property(p => p.Status)
                .HasColumnType("int")
                .HasColumnName("order_status")
                .IsRequired();

            builder
                .Entity<Order>()
                .Property(p => p.UserId)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("order_user_id")
                .IsRequired();

            builder
                .Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity(
                    "ProductOrder",
                    l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
                    r => r.HasOne(typeof(Order)).WithMany().HasForeignKey("OrderId").HasPrincipalKey(nameof(Order.OrderId)),
                    j => j.HasKey("ProductId", "OrderId")
                 );

            builder
                .Entity<Order>()
                .HasOne(x => x.Payment)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
