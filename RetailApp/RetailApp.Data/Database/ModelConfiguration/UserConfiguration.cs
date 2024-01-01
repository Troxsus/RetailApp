using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;

namespace RetailApp.Data.Database.ModelConfiguration
{
    internal static class UserConfiguration
    {
        public static void AddUserConfiguration(this ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .ToTable("users");

            builder
                .Entity<User>()
                .HasKey(x => x.UserId);

            builder
                .Entity<User>()
                .Property(x => x.Username)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("user_username")
                .IsRequired();

            builder
                .Entity<User>()
                .Property(x => x.FirstName)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("user_firstname")
                .IsRequired();

            builder
                .Entity<User>()
                .Property(x => x.LastName)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("user_lastname")
                .IsRequired();

            builder
                .Entity<User>()
                .Property(x => x.Phone)
                .HasColumnType("nvarchar(10)")
                .HasColumnName("user_phone")
                .IsRequired();

            builder
                .Entity<User>()
                .Property(x => x.Email)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("user_email")
                .IsRequired();

            builder
                .Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<User>()
                .HasMany(x => x.Payments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
