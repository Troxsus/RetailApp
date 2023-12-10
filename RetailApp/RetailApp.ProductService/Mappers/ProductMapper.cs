using System;
using System.Collections.Generic;
using RetailApp.BAL.Models;
using RetailApp.ProductService.Protos;

namespace RetailApp.ProductService.Mappers
{
    public static class ProductMapper
    {
        public static ProductReplyList MapToProductListReply(IEnumerable<ProductTransferModel> products)
        {
            var responseProducts = new ProductReplyList();

            foreach (var product in products)
            {
                responseProducts.Products.Add(MapToProductReply(product));
            }

            return responseProducts;
        }

        public static ProductReply MapToProductReply(ProductTransferModel product)
        {
            return new ProductReply
            {
                Id = product.Id.ToString(),
                Category = product.Category,
                Description = product.Description,
                Name = product.Name,
                Price = Convert.ToDouble(product.Price)
            };
        }
    }
}
