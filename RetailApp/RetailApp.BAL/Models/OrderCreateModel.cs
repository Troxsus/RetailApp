using System;
using System.Collections.Generic;

namespace RetailApp.BAL.Models
{
    public class OrderCreateModel
    {
        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public Guid UserId { get; set; }

        public IList<ProductTransferModel> Products { get; set; }
    }
}
