using IShop.Service.Products.Domain.Model;
using IShop.Service.Products.Persistence.Model;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace IShop.Service.Products.Domain
{
    public class ProductService
    {
        //private readonly IMongoDbRepository<Product> productRepository;

        //public ProductService(IMongoDbRepository<Product> productRepository)
        //{
        //    this.productRepository = productRepository;
        //}

        //public async Task<Product> GetProductAsync(ObjectId id)
        //    => await productRepository.GetAsync(product => product.Id == id);

        //public async Task<Product> GetProductSearchAsync(string category, string keyword)
        //    => await productRepository.GetAsync(product => product.Id == id);

        //public async Task<Product> GetProductCategoriesAsync()
        //    => await productRepository.GetAsync(product => product.Id == id);
    }
}
