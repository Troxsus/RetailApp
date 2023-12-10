using System;
using System.Linq;
using RetailApp.Data.Models;
using RetailApp.Data.Models.Enums;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Mappers
{
    internal static class OrderMapper
    {
        public static OrderTransferModel MapToOrderTransferModel(Order order)
        {
            var result = new OrderTransferModel
            {
                Id = order.Id,
                Status = order.Status.ToString(),
                TotalPrice = order.TotalPrice,
                UserId = order.UserId
            };

            result.Products = order.Products.Select(x => ProductMapper.MapToProductTransferModel(x));

            return result;
        }

        public static Order MapToDbOrder(OrderCreateModel order, bool ignoreEnumCase)
        {
            var result = new Order
            {
                Id = Guid.NewGuid(),
                Status = Enum.Parse<OrderStatus>(order.Status, ignoreEnumCase),
                TotalPrice = order.TotalPrice,
                UserId = order.UserId
            };

            var orderProducts = order
                .Products
                .Select(x => ProductMapper.MapToDbProduct(x))
                .ToList();

            result.Products = orderProducts;

            return result;
        }
    }
}
