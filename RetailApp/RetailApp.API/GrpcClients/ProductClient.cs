using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using RetailApp.API.GrpcClients.Interfaces;
using RetailApp.API.Models;
using RetailApp.API.Models.ConfigOptions;
using RetailApp.ProductService.Protos;

namespace RetailApp.API.GrpcClients
{
    public class ProductClient : IProductClient
    {
        private readonly IMapper _mapper;
        private readonly ProductContract.ProductContractClient _productClient;

        public ProductClient(IMapper mapper, IOptions<ServiceAddressOptions> addressOptions)
        {
            _mapper = mapper;

            var channel = GrpcChannel.ForAddress(addressOptions.Value.ProductServiceAddress);
            _productClient = new ProductContract.ProductContractClient(channel);
        }

        public async Task<IEnumerable<ProductDisplay>> GetProducts()
        {
            var products = await _productClient.GetProductsAsync(new EmptyProductRequest());

            return products.Products.Select(x => _mapper.Map<ProductDisplay>(x));
        }

        public async Task<ProductDisplay> GetProductById(Guid productId)
        {
            var request = new ProductIdRequest { Id = productId.ToString() };

            var product = await _productClient.GetProductByIdAsync(request);

            return _mapper.Map<ProductDisplay>(product);
        }
    }
}
