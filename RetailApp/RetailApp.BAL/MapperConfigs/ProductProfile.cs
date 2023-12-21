using AutoMapper;
using RetailApp.BAL.Models;
using RetailApp.Data.Models;

namespace RetailApp.BAL.MapperConfigs
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductTransferModel, Product>().ReverseMap();
        }
    }
}
