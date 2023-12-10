using System.Threading.Tasks;
using Grpc.Core;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.OrderService.Mappers;
using RetailApp.OrderService.Protos;

namespace RetailApp.OrderService.Services
{
    public class OrderService : OrderContract.OrderContractBase
    {
        private readonly IOrderProvider _orderProvider;

        public OrderService(IOrderProvider provider)
        {
            _orderProvider = provider;
        }

        public override Task<OrderReplyList> GetUserOrders(OrderIdRequest request, ServerCallContext context)
        {
            var userOrders = _orderProvider.GetUserOrders(request.Id);

            var response = OrderMapper.MapToOrderReplyList(userOrders);

            return Task.FromResult(response);
        }

        public override Task<OrderReply> GetOrderById(OrderIdRequest request, ServerCallContext context)
        {
            var order = _orderProvider.GetOrderById(request.Id);

            var response = OrderMapper.MapToOrderReply(order);

            return Task.FromResult(response);
        }

        public override Task<OrderBoolReply> CreateOrder(OrderCreateRequest request, ServerCallContext context)
        {
            var orderToCreate = OrderMapper.MapToOrderCreateModel(request);

            var createResult = _orderProvider.CreateOrder(orderToCreate);

            return Task.FromResult(new OrderBoolReply { IsSuccess = createResult });
        }

        public override Task<OrderBoolReply> UpdateOrder(OrderUpdateRequest request, ServerCallContext context)
        {
            var orderToUpdate = OrderMapper.MapToOrderUpdateModel(request);

            var updateResult = _orderProvider.UpdateOrder(orderToUpdate);

            return Task.FromResult(new OrderBoolReply { IsSuccess = updateResult });
        }

        public override Task<OrderBoolReply> DeleteOrder(OrderIdRequest request, ServerCallContext context)
        {
            var deleteResult = _orderProvider.DeleteOrder(request.Id);

            return Task.FromResult(new OrderBoolReply { IsSuccess = deleteResult });
        }
    }
}
