using System;
using RetailApp.ProductService.Protos;
using RetailApp.API.Models;

namespace RetailApp.API.Mappers
{
    public static class ProductApiMapper
    {
        public static ProductDisplay MapToProductDisplay(ProductReply product)
        {
            return new ProductDisplay
            {
                Id = Guid.Parse(product.Id),
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = Convert.ToDecimal(product.Price)
            };
        }

        public static ProductIdRequest MapToProductIdRequest(Guid id)
        {
            return new ProductIdRequest
            {
                Id = id.ToString()
            };
        }
    }
}
