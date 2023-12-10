using System;

namespace RetailApp.BAL.Models
{
    public class OrderUpdateModel
    {
        public Guid Id { get; set; }

        public string Status { get; set; }
    }
}
