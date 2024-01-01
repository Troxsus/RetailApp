using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;

namespace RetailApp.Data.Database.ModelConfiguration
{
    internal static class ProductConfiguration
    {
        public static void AddProductConfiguration(this ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .ToTable("products");

            builder
                .Entity<Product>()
                .HasKey(x => x.ProductId);

            builder
                .Entity<Product>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("product_name")
                .IsRequired();

            builder
                .Entity<Product>()
                .Property(x => x.Description)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("product_description");

            builder
                .Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(4)
                .HasColumnType("float")
                .HasColumnName("product_price")
                .IsRequired();

            builder
                .Entity<Product>()
                .Property(x => x.Category)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("product_category")
                .IsRequired();
        }
    }
}
