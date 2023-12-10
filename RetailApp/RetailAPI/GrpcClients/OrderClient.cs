using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Grpc.Core;
using Grpc.Net.Client;
using RetailApp.OrderService.Protos;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Mappers;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;



namespace RetailApp.API.GrpcClients
{
    public class OrderClient : IOrderClient
    {
        private readonly OrderContract.OrderContractClient _orderGrpcClient;

        public OrderClient(IOptions<ServiceAddressOptions> addressOptions)
        {
            var channel = GrpcChannel.ForAddress(addressOptions.Value.OrderServiceAddress);
            _orderGrpcClient = new OrderContract.OrderContractClient(channel);
        }

        public async Task<IEnumerable<OrderDisplay>> GetUserOrders(Guid userId)
        {
            try
            {
                var request = OrderApiMapper.MapToOrderIdRequest(userId);

                var response = await _orderGrpcClient.GetUserOrdersAsync(request);

                var orders = response.Orders.Select(x => OrderApiMapper.MapToOrderDisplay(x));

                return orders;
            }
            catch (RpcException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDisplay> GetOrderById(Guid orderId)
        {
            try 
            { 
                var request = OrderApiMapper.MapToOrderIdRequest(orderId);

                var response = await _orderGrpcClient.GetOrderByIdAsync(request);

                return OrderApiMapper.MapToOrderDisplay(response);
            }
            catch (RpcException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateOrder(OrderCreate orderInfo)
        {
            try
            {
                var request = OrderApiMapper.MapToOrderCreateRequest(orderInfo);
        
                var response = await _orderGrpcClient.CreateOrderAsync(request);
        
                return response.IsSuccess;
            }
            catch (RpcException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateOrder(OrderUpdate orderInfo)
        {
            try 
            { 
                var request = OrderApiMapper.MapToOrderUpdateRequest(orderInfo);

                var response = await _orderGrpcClient.UpdateOrderAsync(request);

                return response.IsSuccess;
            }
            catch (RpcException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            try 
            { 
                var request = OrderApiMapper.MapToOrderIdRequest(orderId);

                var response = await _orderGrpcClient.DeleteOrderAsync(request);

                return response.IsSuccess;
            }
            catch (RpcException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
