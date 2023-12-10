using System;
using System.Collections.Generic;
using System.Linq;
using RetailApp.BAL.Models;
using RetailApp.OrderService.Protos;

namespace RetailApp.OrderService.Mappers
{
    public static class OrderMapper
    {
        public static OrderReplyList MapToOrderReplyList(IEnumerable<OrderTransferModel> orders)
        {
            var response = new OrderReplyList();

            var mappedOrders = orders.Select(x => MapToOrderReply(x));
            response.Orders.AddRange(mappedOrders);

            return response;
        }

        public static OrderReply MapToOrderReply(OrderTransferModel order)
        {
            return new OrderReply
            {
                OrderId = order.Id.ToString(),
                Status = order.Status.ToString(),
                TotalPrice = (double)order.TotalPrice,
                UserId = order.UserId.ToString(),
                Products = MapToOrderProductList(order.Products)
            };
        }

        public static OrderProductList MapToOrderProductList(IEnumerable<ProductTransferModel> products)
        {
            var responseProducts = new OrderProductList();

            foreach (var product in products)
            {
                var responseProduct = MapToOrderProduct(product);

                responseProducts.Products.Add(responseProduct);
            }

            return responseProducts;
        }

        public static OrderUpdateModel MapToOrderUpdateModel(OrderUpdateRequest orderUpdate)
        {
            return new OrderUpdateModel
            {
                Id = Guid.Parse(orderUpdate.Id),
                Status = orderUpdate.Status,
            };
        }

        public static OrderCreateModel MapToOrderCreateModel(OrderCreateRequest order)
        {
            return new OrderCreateModel
            {
                Status = order.Status,
                TotalPrice = Convert.ToDecimal(order.TotalPrice),
                Products = order.Products.Select(x => MapToProductTransferModel(x)),
                UserId = Guid.Parse(order.UserId),
            };
        }

        private static ProductTransferModel MapToProductTransferModel(OrderProduct orderProduct)
        {
            return new ProductTransferModel
            {
                Id = Guid.Parse(orderProduct.Id),
                Category = orderProduct.Category,
                Description = orderProduct.Description,
                Name = orderProduct.Name,
                Price = Convert.ToDecimal(orderProduct.Price)
            };
        }

        private static OrderProduct MapToOrderProduct(ProductTransferModel product)
        {
            return new OrderProduct
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description,
                Price = (double)product.Price,
                Category = product.Category
            };
        }
    }
}
