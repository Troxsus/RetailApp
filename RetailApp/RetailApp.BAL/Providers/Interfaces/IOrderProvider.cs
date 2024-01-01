using System.Collections.Generic;
using RetailApp.BAL.Models;

namespace RetailApp.BAL.Providers.Interfaces
{
    public interface IOrderProvider : IProvider
    {
        IEnumerable<OrderTransferModel> GetUserOrders(string userId);

        OrderTransferModel GetOrderById(string orderId);

        bool CreateOrder(OrderCreateModel request);

        bool UpdateOrder(OrderUpdateModel orderToUpdate);

        bool DeleteOrder(string orderId);
    }
}
