using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models;
using RetailApp.Data.Models.Enums;

namespace RetailApp.Data.Extensions
{
    public static class ModelBuilderExtensionsDataSeed
    {
        public static void SeedData(this ModelBuilder builder)
        {
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var user3Id = Guid.NewGuid();
            var user4Id = Guid.NewGuid();

            var users = new List<User>
            {
                new User
                {
                    UserId = user1Id,
                    FirstName = "Mark",
                    LastName = "Shawn",
                    Phone = "1234567890",
                    Email = "randomEmail@gmail.com",
                    Username = "MarkMan23"
                },
                new User
                {
                    UserId = user2Id,
                    FirstName = "Ron",
                    LastName = "Lee",
                    Phone = "1243569870",
                    Email = "RonEmail@gmail.com",
                    Username = "RonRock23"
                },
                new User
                {
                    UserId = user3Id,
                    FirstName = "Silvester",
                    LastName = "Sheen",
                    Phone = "1234567890",
                    Email = "SilvesterEmail@gmail.com",
                    Username = "BoogieMan23"
                },
                new User
                {
                    UserId = user4Id,
                    FirstName = "Mick",
                    LastName = "Flanders",
                    Phone = "1234567890",
                    Email = "MickEmail@gmail.com",
                    Username = "Gordon46"
                }
            };

            var product1Id = Guid.NewGuid();
            var product2Id = Guid.NewGuid();
            var product3Id = Guid.NewGuid();
            var product4Id = Guid.NewGuid();
            var product5Id = Guid.NewGuid();
            var product6Id = Guid.NewGuid();
            var product7Id = Guid.NewGuid();
            var product8Id = Guid.NewGuid();
            var product9Id = Guid.NewGuid();
            var product10Id = Guid.NewGuid();
            var product11Id = Guid.NewGuid();
            var product12Id = Guid.NewGuid();
            var product13Id = Guid.NewGuid();
            var product14Id = Guid.NewGuid();
            var product15Id = Guid.NewGuid();

            var products = new List<Product>
            {
                new Product
                {
                    ProductId = product1Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "Sony extra bass headset",
                    Price = 120
                },
                new Product
                {
                    ProductId = product2Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "AlianX P47",
                    Price = 13
                },
                new Product
                {
                    ProductId = product3Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "J7 Pro",
                    Price = 39
                },
                new Product
                {
                    ProductId = product4Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "ROTTER",
                    Price = 48.88M
                },
                new Product
                {
                    ProductId = product5Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "Totalshop P47",
                    Price = 12
                },
                new Product
                {
                    ProductId = product6Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "Pebble",
                    Price = 79
                },
                new Product
                {
                    ProductId = product7Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "Sony extra bass headset",
                    Price = 120
                },
                new Product
                {
                    ProductId = product8Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "Pimpom 800HB",
                    Price = 55
                },
                new Product
                {
                    ProductId = product9Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "CLUSTERZEN K18",
                    Price = 70.08M
                },
                new Product
                {
                    ProductId = product10Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "Baseus E8",
                    Price = 72
                },
                new Product
                {
                    ProductId = product11Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "VCom M280",
                    Price = 35.70M
                },
                new Product
                {
                    ProductId = product12Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "Louise&Mann",
                    Price = 47.63M
                },
                new Product
                {
                    ProductId = product13Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "ZTE Buds",
                    Price = 59.99M
                },
                new Product
                {
                    ProductId = product14Id,
                    Description = "Headset",
                    Category = "Headphones",
                    Name = "XO BE23",
                    Price = 49.99M
                },
                new Product
                {
                    ProductId = product15Id,
                    Description = "Portable",
                    Category = "Earplugs",
                    Name = "SP16",
                    Price = 37.36M
                }
            };

            var order1Id = Guid.NewGuid();
            var order2Id = Guid.NewGuid();
            var order3Id = Guid.NewGuid();
            var order4Id = Guid.NewGuid();

            var orders = new List<Order>
            {
                new Order
                {
                    OrderId = order1Id,
                    Status = OrderStatus.Placed,
                    TotalPrice = 120,
                    UserId = user1Id,
                },
                new Order
                {
                    OrderId = order2Id,
                    Status = OrderStatus.Shipping,
                    TotalPrice = 120,
                    UserId = user1Id,
                },
                new Order
                {
                    OrderId = order3Id,
                    Status = OrderStatus.Completed,
                    TotalPrice = 120,
                    UserId = user1Id,
                },
                new Order
                {
                    OrderId = order4Id,
                    Status = OrderStatus.Completed,
                    TotalPrice = 120,
                    UserId = user2Id,
                }
            };

            var payment = new List<Payment>
            {
                new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    Price = 12,
                    CreatedOn = DateTime.Now,
                    UserId = user1Id,
                    OrderId = order1Id
                },
                new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    Price = 169.99M,
                    CreatedOn = DateTime.Now,
                    UserId = user1Id,
                    OrderId = order2Id
                },
                new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    Price = 37.36M,
                    CreatedOn = DateTime.Now,
                    UserId = user1Id,
                    OrderId = order3Id
                },
                new Payment
                {
                    PaymentId = Guid.NewGuid(),
                    Price = 37.36M,
                    CreatedOn = DateTime.Now,
                    UserId = user2Id,
                    OrderId = order4Id
                }
            };

            builder.Entity("ProductOrder")
            .HasData(new[]
                {
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order1Id,
                        ProductId = product1Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order1Id,
                        ProductId = product2Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order1Id,
                        ProductId = product3Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order1Id,
                        ProductId = product4Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order1Id,
                        ProductId = product5Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order2Id,
                        ProductId = product6Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order2Id,
                        ProductId = product7Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order3Id,
                        ProductId = product8Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order4Id,
                        ProductId = product9Id
                    },
                    new
                    {
                        Id = Guid.NewGuid(),
                        OrderId = order4Id,
                        ProductId = product10Id
                    }
                }
            );

            builder.Entity<User>().HasData(users);
            builder.Entity<Order>().HasData(orders);
            builder.Entity<Product>().HasData(products);
            builder.Entity<Payment>().HasData(payment);
        }
    }
}
