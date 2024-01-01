﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Grpc.Net.Client;
using AutoMapper;
using RetailApp.OrderService.Protos;
using RetailApp.API.Clients.Interfaces;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;

namespace RetailApp.API.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly IMapper _mapper;
        private readonly OrderContract.OrderContractClient _orderClient;

        public OrderClient(IMapper mapper, IOptions<ServiceAddressOptions> addressOptions)
        {
            _mapper = mapper;

            var channel = GrpcChannel.ForAddress(addressOptions.Value.OrderServiceAddress);
            _orderClient = new OrderContract.OrderContractClient(channel);
        }

        public async Task<IEnumerable<OrderDisplay>> GetUserOrders(Guid userId)
        {
            var request = new OrderIdRequest { Id = userId.ToString() };

            var response = await _orderClient.GetUserOrdersAsync(request);

            var orders = response.Orders.Select(x => _mapper.Map<OrderDisplay>(x));

            return orders;
        }

        public async Task<OrderDisplay> GetOrderById(Guid orderId)
        {
            var request = new OrderIdRequest { Id = orderId.ToString() };

            var response = await _orderClient.GetOrderByIdAsync(request);

            return _mapper.Map<OrderDisplay>(response);
        }

        public async Task<bool> CreateOrder(OrderCreate orderInfo)
        {
            var request = _mapper.Map<OrderCreateRequest>(orderInfo);
            
            var response = await _orderClient.CreateOrderAsync(request);
            
            return response.IsSuccess;
        }

        public async Task<bool> UpdateOrder(OrderUpdate orderInfo)
        {
            var request = _mapper.Map<OrderUpdateRequest>(orderInfo);

            var response = await _orderClient.UpdateOrderAsync(request);

            return response.IsSuccess;
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var request = new OrderIdRequest { Id = orderId.ToString() };

            var response = await _orderClient.DeleteOrderAsync(request);

            return response.IsSuccess;
        }
    }
}
