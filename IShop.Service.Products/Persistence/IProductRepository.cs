using IShop.Service.Products.Domain.Model;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
    }
}