using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.OrderService.Protos;

namespace RetailApp.OrderService.MapperConfig
{
    public class OrderGrpcProfile : Profile
    {
        public OrderGrpcProfile()
        {
            CreateMap<OrderTransferModelList, OrderReplyList>();

            CreateMap<OrderTransferModel, OrderReply>();

            CreateMap<OrderUpdateRequest, OrderUpdateModel>();

            CreateMap<OrderCreateRequest, OrderCreateModel>();

            CreateMap<ProductTransferModel, OrderProduct>().ReverseMap();
        }
    }
}
