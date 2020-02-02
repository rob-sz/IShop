using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public interface ICategoryRepository
    {
        Task<Domain.Model.Category> GetCategoryAsync(string name);
        
        Task<IEnumerable<Domain.Model.Category>> GetCategoriesAsync();

        Task CreateCategoryAsync(Domain.Model.Category entity);
    }
}