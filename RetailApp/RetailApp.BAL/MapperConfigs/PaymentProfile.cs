using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.Data.Models;

namespace RetailApp.BAL.MapperConfigs
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateModel, Payment>();

            CreateMap<Payment, PaymentTransferModel>();
        }
    }
}
