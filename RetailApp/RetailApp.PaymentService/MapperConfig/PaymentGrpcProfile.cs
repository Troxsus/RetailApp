using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.PaymentService.Protos;

namespace RetailApp.PaymentService.MapperConfig
{
    public class PaymentGrpcProfile : Profile
    {
        public PaymentGrpcProfile()
        {
            CreateMap<PaymentCreateRequest, PaymentCreateModel>();
            
            CreateMap<PaymentTransferModel, PaymentReply>();

            CreateMap<PaymentTransferModelList ,PaymentListReply>();
        }
    }
}
