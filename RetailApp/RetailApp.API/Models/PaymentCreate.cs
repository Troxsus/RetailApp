using System;

namespace RetailApp.API.Models
{
    public class PaymentCreate
    {
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UserId { get; set; }

        public Guid OrderId { get; set; }
    }
}
