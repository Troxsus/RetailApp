using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RetailApp.Data.Models.Enums;
using RetailApp.Data.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Providers
{
    public class OrderProvider : BaseProvider<Order>, IOrderProvider
    {
        public OrderProvider(IMapper mapper)
            : base(mapper)
        { }
        
        public IEnumerable<OrderTransferModel> GetUserOrders(string userId)
        {
            var userIdAsGuid = Guid.Parse(userId);

            var userOrders = 
                base.GetAll()
                .Where(x => x.UserId == userIdAsGuid)
                .Include(x => x.Products)
                .Select(x => _mapper.Map<OrderTransferModel>(x))
                .ToList();

            return userOrders;
        }

        public OrderTransferModel GetOrderById(string orderId)
        {
            var idAsGuid = Guid.Parse(orderId);
            var order = 
                base.GetAll()
                .Where(x => x.OrderId == idAsGuid)
                .Include(x => x.Products)
                .FirstOrDefault();

            return _mapper.Map<OrderTransferModel>(order);
        }

        public bool CreateOrder(OrderCreateModel request)
        {
            var orderToCreate = _mapper.Map<Order>(request);
            
            base.Create(orderToCreate);

            return true;
        }

        public bool UpdateOrder(OrderUpdateModel orderToUpdate)
        {
            var order = _repository.GetById(orderToUpdate.OrderId);
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
