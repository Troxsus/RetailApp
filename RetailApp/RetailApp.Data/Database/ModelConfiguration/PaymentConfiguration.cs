using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;

namespace RetailApp.Data.Database.ModelConfiguration
{
    internal static class PaymentConfiguration
    {
        public static void AddPaymentConfiguration(this ModelBuilder builder)
        {
            builder
                .Entity<Payment>()
                .ToTable("payments");

            builder
                .Entity<Payment>()
                .HasKey(x => x.PaymentId);

            builder
                .Entity<Payment>()
                .Property(x => x.Price)
                .HasPrecision(4)
                .HasColumnType("float")
                .HasColumnName("payment_price")
                .IsRequired();
            
            builder
                .Entity<Payment>()
                .Property(x => x.CreatedOn)
                .HasColumnType("datetime2")
                .HasColumnName("payment_createdon")
                .IsRequired();

            builder
                .Entity<Payment>()
                .Property(x => x.UserId)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("payment_user_id")
                .IsRequired();

            builder
                .Entity<Payment>()
                .Property(x => x.OrderId)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("payment_order_id")
                .IsRequired();
        }
    }
}
