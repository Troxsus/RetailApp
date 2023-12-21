using System;

namespace RetailApp.Data.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UserId { get; set; }

        public Guid OrderId { get; set; }

        public User User { get; set; }

        public Order Order { get; set; }
    }
}
