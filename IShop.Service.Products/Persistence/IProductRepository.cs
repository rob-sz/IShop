using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public interface IProductRepository
    {
        Task<Domain.Model.Product> GetProductAsync(Guid id);
        
        Task<IEnumerable<Domain.Model.Product>> GetProductsAsync(
            string category, string keyword);

        Task CreateProductAsync(Domain.Model.Product entity);
    }
}