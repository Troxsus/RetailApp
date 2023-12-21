using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Grpc.Net.Client;
using AutoMapper;
using RetailApp.OrderService.Protos;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;

namespace RetailApp.API.GrpcClients
{
    public class OrderClient : IOrderClient
    {
        private readonly IMapper _mapper;
        private readonly OrderContract.OrderContractClient _orderGrpcClient;

        public OrderClient(IMapper mapper, IOptions<ServiceAddressOptions> addressOptions)
        {
            _mapper = mapper;

            var channel = GrpcChannel.ForAddress(addressOptions.Value.OrderServiceAddress);
            _orderGrpcClient = new OrderContract.OrderContractClient(channel);
        }

        public async Task<IEnumerable<OrderDisplay>> GetUserOrders(Guid userId)
        {
            var request = new OrderIdRequest { Id = userId.ToString() };

            var response = await _orderGrpcClient.GetUserOrdersAsync(request);

            var orders = response.Orders.Select(x => _mapper.Map<OrderDisplay>(x));

            return orders;
        }

        public async Task<OrderDisplay> GetOrderById(Guid orderId)
        {
            var request = new OrderIdRequest { Id = orderId.ToString() };

            var response = await _orderGrpcClient.GetOrderByIdAsync(request);

            return _mapper.Map<OrderDisplay>(response);
        }

        public async Task<bool> CreateOrder(OrderCreate orderInfo)
        {
            var request = _mapper.Map<OrderCreateRequest>(orderInfo);
            
            var response = await _orderGrpcClient.CreateOrderAsync(request);
            
            return response.IsSuccess;
        }

        public async Task<bool> UpdateOrder(OrderUpdate orderInfo)
        {
            var request = _mapper.Map<OrderUpdateRequest>(orderInfo);

            var response = await _orderGrpcClient.UpdateOrderAsync(request);

            return response.IsSuccess;
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var request = new OrderIdRequest { Id = orderId.ToString() };

            var response = await _orderGrpcClient.DeleteOrderAsync(request);

            return response.IsSuccess;
        }
    }
}
