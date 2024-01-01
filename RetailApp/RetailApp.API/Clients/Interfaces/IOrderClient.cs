using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RetailApp.API.Models;

namespace RetailApp.API.Clients.Interfaces
{
    public interface IOrderClient
    {
        Task<IEnumerable<OrderDisplay>> GetUserOrders(Guid userId);
        
        Task<OrderDisplay> GetOrderById(Guid orderId);
        
        Task<bool> CreateOrder(OrderCreate request);

        Task<bool> UpdateOrder(OrderUpdate request);

        Task<bool> DeleteOrder(Guid request);
    }
}
