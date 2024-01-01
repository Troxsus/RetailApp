using System;

namespace RetailApp.API.Models
{
    public class OrderUpdate
    {
        public Guid OrderId { get; set; }

        public string Status { get; set; }
    }
}
