using System;

namespace RetailApp.BAL.Models
{
    public class OrderUpdateModel
    {
        public Guid OrderId { get; set; }

        public string Status { get; set; }
    }
}
