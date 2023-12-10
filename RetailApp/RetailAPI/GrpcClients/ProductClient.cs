using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Mappers;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;
using RetailApp.ProductService.Protos;

namespace RetailApp.API.GrpcClients
{
    public class ProductClient : IProductClient
    {
        private readonly ProductContract.ProductContractClient _productClient;

        public ProductClient(IOptions<ServiceAddressOptions> addressOptions)
        {
            var channel = GrpcChannel.ForAddress(addressOptions.Value.ProductServiceAddress);
            _productClient = new ProductContract.ProductContractClient(channel);
        }

        public async Task<IEnumerable<ProductDisplay>> GetProducts()
        {
            var products = await _productClient.GetProductsAsync(new EmptyProductRequest());

            return products.Products.Select(x => ProductApiMapper.MapToProductDisplay(x));
        }

        public async Task<ProductDisplay> GetProductById(Guid productId)
        {
            var request = ProductApiMapper.MapToProductIdRequest(productId);

            var product = await _productClient.GetProductByIdAsync(request);

            return ProductApiMapper.MapToProductDisplay(product);
        }
    }
}
