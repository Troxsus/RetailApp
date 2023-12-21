﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RetailApp.Data.Models;
using RetailApp.BAL.Models;
using RetailApp.BAL.Providers.Interfaces;
using RetailApp.Data.Providers.Interfaces;

namespace RetailApp.BAL.Providers
{
    public class ProductProvider : BaseProvider<Product>, IProductProvider
    {
        public ProductProvider(IMapper mapper, IDbRepositoryProvider provider)
            : base(mapper)
        {
            _repository = provider.GetRepository<Product>();
        }

        public IEnumerable<ProductTransferModel> GetProducts()
        {
            var products = base
                .GetAll()
                .Select(x => _mapper.Map<ProductTransferModel>(x))
                .ToList();

            return products;
        }

        public ProductTransferModel GetProductById(string productId)
        {
            var product = base.GetById(productId);

            return _mapper.Map<ProductTransferModel>(product);
        }
    }
}
