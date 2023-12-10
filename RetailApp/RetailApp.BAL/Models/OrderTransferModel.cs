using System;
using System.Collections.Generic;

namespace RetailApp.BAL.Models
{
    public class OrderTransferModel
    {
        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<ProductTransferModel> Products { get; set; }
    }
}
