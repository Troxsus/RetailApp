using System;
using System.Linq;
using RetailApp.OrderService.Protos;
using RetailApp.API.Models;

namespace RetailApp.API.Mappers
{
    public static class OrderApiMapper
    {
        public static OrderDisplay MapToOrderDisplay(OrderReply reply)
        {
            return new OrderDisplay
            {
                OrderId = Guid.Parse(reply.OrderId),
                Status = reply.Status,
                UserId = Guid.Parse(reply.UserId),
                TotalPrice = Convert.ToDecimal(reply.TotalPrice),
                Products = reply.Products.Products.Select(x => MapToProductDisplay(x))
            };
        }

        public static OrderIdRequest MapToOrderIdRequest(Guid id)
        {
            return new OrderIdRequest
            {
                Id = id.ToString()
            };
        }

        public static OrderUpdateRequest MapToOrderUpdateRequest(OrderUpdate order)
        {
            return new OrderUpdateRequest
            {
                Id = order.Id.ToString(),
                Status = order.Status
            };
        }

        public static OrderCreateRequest MapToOrderCreateRequest(OrderCreate order)
        {
            var orderToCreate = new OrderCreateRequest
            {
                Status = order.Status,
                TotalPrice = Convert.ToDouble(order.TotalPrice),
                UserId = order.UserId.ToString()
            };

            var mappedProducts = order.Products.Select(x => MapToOrderProduct(x));
            orderToCreate.Products.AddRange(mappedProducts);

            return orderToCreate;
        }

        private static OrderProduct MapToOrderProduct(ProductDisplay product)
        {
            return new OrderProduct
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = Convert.ToDouble(product.Price)
            };
        }

        private static ProductDisplay MapToProductDisplay(OrderProduct product)
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
    }
}
