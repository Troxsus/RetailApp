using AutoMapper;
using RetailApp.API.Models;
using RetailApp.PaymentService.Protos;

namespace RetailApp.API.MapperConfigs
{
    public class PaymentApiProfile : Profile
    {
        public PaymentApiProfile()
        {
            CreateMap<PaymentCreate, PaymentCreateRequest>();

            CreateMap<PaymentReply, PaymentDisplay>();
        }
    }
}
