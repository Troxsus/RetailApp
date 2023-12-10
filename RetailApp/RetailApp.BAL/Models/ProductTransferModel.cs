using System;

namespace RetailApp.BAL.Models
{
    public class ProductTransferModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
