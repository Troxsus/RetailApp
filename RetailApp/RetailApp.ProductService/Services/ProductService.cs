using System.Threading.Tasks;
using Grpc.Core;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.ProductService.Mappers;
using RetailApp.ProductService.Protos;

namespace RetailApp.ProductService.Services
{
    public class ProductService : ProductContract.ProductContractBase
    {
        private readonly IProductProvider _productProvider;

        public ProductService(IProductProvider provider)
        {
            _productProvider = provider;
        }

        public override Task<ProductReplyList> GetProducts(EmptyProductRequest request, ServerCallContext context)
        {
            var products = _productProvider.GetProducts();

            var response = ProductMapper.MapToProductListReply(products);

            return Task.FromResult(response);
        }

        public override Task<ProductReply> GetProductById(ProductIdRequest request, ServerCallContext context)
        {
            var product = _productProvider.GetProductById(request.Id);

            var response = ProductMapper.MapToProductReply(product);

            return Task.FromResult(response);
        }
    }
}
