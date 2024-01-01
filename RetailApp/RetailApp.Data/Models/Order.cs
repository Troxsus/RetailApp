using System;
using System.Collections.Generic;
using RetailApp.Data.Models.Enums;

namespace RetailApp.Data.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Payment Payment { get; set; }

        public List<Product> Products { get; set; }
    }
}
