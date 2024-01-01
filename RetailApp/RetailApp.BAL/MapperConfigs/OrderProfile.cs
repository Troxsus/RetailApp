using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.Data.Models;

namespace RetailApp.BAL.MapperConfigs
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateModel, Order>();

            CreateMap<Order, OrderTransferModel>();
        }
    }
}
