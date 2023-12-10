using System.Collections.Generic;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Providers.Interfaces
{
    public interface IProductProvider
    {
        IEnumerable<ProductTransferModel> GetProducts();

        ProductTransferModel GetProductById(string productId);
    }
}
