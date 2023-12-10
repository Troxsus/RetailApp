using System.Collections.Generic;
using System.Linq;
using RetailApp.Data.Models;
using RetailApp.Data.Repository.Interfaces;
using RetailApp.BAL.Mappers;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;


namespace RetailApp.BAL.Providers
{
    public class ProductProvider : BaseProvider<Product>, IProductProvider
    {
        public ProductProvider(IDbContextRepository<Product> productsRepository)
            : base(productsRepository)
        { }

        public IEnumerable<ProductTransferModel> GetProducts()
        {
            var products = base
                .GetAll()
                .Select(x => ProductMapper.MapToProductTransferModel(x))
                .ToList();

            return products;
        }

        public ProductTransferModel GetProductById(string productId)
        {
            var product = base.GetById(productId);

            return ProductMapper.MapToProductTransferModel(product);
        }
    }
}
