using AutoMapper;
using RetailApp.API.Models;
using RetailApp.ProductService.Protos;

namespace RetailApp.API.MapperConfigs
{
    public class ProductApiProfile : Profile
    {
        public ProductApiProfile() 
        {
            CreateMap<ProductReply, ProductDisplay>();
        }
    }
}
