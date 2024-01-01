using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using RetailApp.Data.ConfigOptions.Enums;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.OrderService.Protos;

namespace RetailApp.OrderService.Services
{
    public class OrderService : OrderContract.OrderContractBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderProvider _orderProvider;

        public OrderService(IMapper mapper, IOrderProvider provider)
        {
            _mapper = mapper;
            _orderProvider = provider;
            _orderProvider.ConfigureProviderRepository(DbContextTypes.RetailApp);
        }

        public override Task<OrderReplyList> GetUserOrders(OrderIdRequest request, ServerCallContext context)
        {
            var userOrders = _orderProvider.GetUserOrders(request.Id);
            var orderList = new OrderTransferModelList { Orders = new List<OrderTransferModel>(userOrders) };

            var response = _mapper.Map<OrderReplyList>(orderList);

            return Task.FromResult(response);
        }

        public override Task<OrderReply> GetOrderById(OrderIdRequest request, ServerCallContext context)
        {
            var order = _orderProvider.GetOrderById(request.Id);

            var response = _mapper.Map<OrderReply>(order);

            return Task.FromResult(response);
        }

        public override Task<OrderBoolReply> CreateOrder(OrderCreateRequest request, ServerCallContext context)
        {
            var orderToCreate = _mapper.Map<OrderCreateModel>(request);

            var createResult = _orderProvider.CreateOrder(orderToCreate);

            return Task.FromResult(new OrderBoolReply { IsSuccess = createResult });
        }

        public override Task<OrderBoolReply> UpdateOrder(OrderUpdateRequest request, ServerCallContext context)
        {
            var orderToUpdate = _mapper.Map<OrderUpdateModel>(request);

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
