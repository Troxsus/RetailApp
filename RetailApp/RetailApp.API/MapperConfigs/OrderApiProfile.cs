using System;
using System.Collections.Generic;
using AutoMapper;
using Google.Protobuf.Collections;
using RetailApp.API.Models;
using RetailApp.OrderService.Protos;

namespace RetailApp.API.MapperConfigs
{
    public class OrderApiProfile : Profile
    {
        public OrderApiProfile()
        {
            CreateMap<OrderReply, OrderDisplay>();
            
            CreateMap<Guid ,OrderIdRequest>();

            CreateMap<OrderUpdate, OrderUpdateRequest>();
            
            CreateMap<OrderCreate, OrderCreateRequest>();
                        
            CreateMap<OrderProduct, ProductDisplay>().ReverseMap();
        }
    }
}
