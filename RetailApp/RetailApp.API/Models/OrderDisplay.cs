using System;
using System.Collections.Generic;

namespace RetailApp.API.Models
{
    public class OrderDisplay
    {
        public Guid  OrderId {  get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public string Status { get; set; }
        
        public Guid UserId { get; set; }

        public IList<ProductDisplay> Products { get; set; }
    }
}
