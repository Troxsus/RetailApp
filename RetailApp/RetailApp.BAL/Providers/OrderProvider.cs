using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RetailApp.Data.Models.Enums;
using RetailApp.Data.Models;
using RetailApp.Data.Repository.Interfaces;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.BAL.Models;
using RetailApp.BAL.Mappers;

namespace RetailApp.BAL.Providers
{
    public class OrderProvider : BaseProvider<Order>, IOrderProvider
    {
        public OrderProvider(IDbContextRepository<Order> repository)
            : base(repository)
        { }

        public IEnumerable<OrderTransferModel> GetUserOrders(string userId)
        {
            var userIdAsGuid = Guid.Parse(userId);

            var userOrders = 
                base.GetAll()
                .Where(x => x.UserId == userIdAsGuid)
                .Include(x => x.Products)
                .Select(x => OrderMapper.MapToOrderTransferModel(x))
                .ToList();

            return userOrders;
        }

        public OrderTransferModel GetOrderById(string orderId)
        {
            var order = base.GetById(orderId);

            return OrderMapper.MapToOrderTransferModel(order);
        }

        public bool CreateOrder(OrderCreateModel request)
        {
            var ignoreCase = true;
            var orderToCreate = OrderMapper.MapToDbOrder(request, ignoreCase);
            
            base.Create(orderToCreate);

            return true;
        }

        public bool UpdateOrder(OrderUpdateModel orderToUpdate)
        {
            var order = _repository.GetById(orderToUpdate.Id);
            order.Status = Enum.Parse<OrderStatus>(orderToUpdate.Status, true);

            base.Update(order);

            return true;
        }

        public bool DeleteOrder(string orderId)
        {
            base.Delete(orderId);

            return true;
        }
    }
}
