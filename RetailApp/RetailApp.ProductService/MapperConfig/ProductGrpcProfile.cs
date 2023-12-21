using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.ProductService.Protos;

namespace RetailApp.ProductService.MapperConfig
{
    public class ProductGrpcProfile : Profile
    {
        public ProductGrpcProfile()
        {
            CreateMap<ProductTransferModel, ProductReply>();

            CreateMap<ProductTransferModelList, ProductReplyList>();
        }
    }
}
