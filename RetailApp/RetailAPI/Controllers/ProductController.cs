using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetailApp.API.GrpcClients.Interfaces;

namespace RetailApp.API.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductClient _productClient;

        public ProductController(IProductClient productClient)
        {
            _productClient = productClient;
        }

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> GetProducts()
        {
            var products = await _productClient.GetProducts();

            return new JsonResult(products);
        }

        [HttpGet] // add route
        public async Task<JsonResult> GetProductById(Guid productId)
        {
            var product = await _productClient.GetProductById(productId);

            return new JsonResult(product);
        }
    }
}
