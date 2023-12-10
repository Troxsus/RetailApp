using System;

namespace RetailApp.API.Models
{
    public class OrderUpdate
    {
        public Guid Id { get; set; }

        public string Status { get; set; }
    }
}
