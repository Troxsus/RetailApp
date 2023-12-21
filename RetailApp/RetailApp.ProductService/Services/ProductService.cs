using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.ProductService.Protos;

namespace RetailApp.ProductService.Services
{
    public class ProductService : ProductContract.ProductContractBase
    {
        private readonly IMapper _mapper;
        private readonly IProductProvider _productProvider;

        public ProductService(IMapper mapper, IProductProvider provider)
        {
            _mapper = mapper;
            _productProvider = provider;
        }

        public override Task<ProductReplyList> GetProducts(EmptyProductRequest request, ServerCallContext context)
        {
            var products = _productProvider.GetProducts();
            var productList = new ProductTransferModelList { Products = new List<ProductTransferModel>(products) };

            var response = _mapper.Map<ProductReplyList>(productList);

            return Task.FromResult(response);
        }

        public override Task<ProductReply> GetProductById(ProductIdRequest request, ServerCallContext context)
        {
            var product = _productProvider.GetProductById(request.Id);

            var response = _mapper.Map<ProductReply>(product);

            return Task.FromResult(response);
        }
    }
}
