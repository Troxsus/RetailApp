using System;

namespace RetailApp.BAL.Models
{
    public class PaymentCreateModel
    {
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid UserId { get; set; }

        public Guid OrderId { get; set; }
    }
}
