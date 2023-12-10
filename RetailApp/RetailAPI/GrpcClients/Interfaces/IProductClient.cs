using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RetailApp.API.Models;

namespace RetailApp.API.GrpcClients.Interfaces
{
    public interface IProductClient
    {
        Task<IEnumerable<ProductDisplay>> GetProducts();
        
        Task<ProductDisplay> GetProductById(Guid productId);
    }
}
