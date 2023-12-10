using RetailApp.Data.Models;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Mappers
{
    internal static class ProductMapper
    {
        public static ProductTransferModel MapToProductTransferModel(Product prod)
        {
            return new ProductTransferModel
            {
                Id = prod.Id,
                Name = prod.Name,
                Category = prod.Category,
                Description = prod.Description,
                Price = prod.Price,
            };
        }

        public static Product MapToDbProduct(ProductTransferModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
