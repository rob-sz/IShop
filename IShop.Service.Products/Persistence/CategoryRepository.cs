using AutoMapper;
using IShop.Common.Mongo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper mapper;
        private readonly IMongoDbRepository<Persistence.Model.Category> repository;

        public CategoryRepository(
            IMapper mapper,
            IMongoDbRepository<Persistence.Model.Category> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<Domain.Model.Category> GetCategoryAsync(string name)
        {
            var persistenceModel = await repository.GetAsync(
                entity => entity.Name.ToLower() == name.ToLower());

            var domainModel = mapper.Map<Domain.Model.Category>(persistenceModel);

            return domainModel;
        }

        public async Task<IEnumerable<Domain.Model.Category>> GetCategoriesAsync()
        {
            /*
            var category1 = new Persistence.Model.Category
            {
                Name = "Electronics",
                Description = "Electronic goods."
            };
            await repository.CreateAsync(category1);
            
            var category2 = new Persistence.Model.Category
            {
                Name = "Toys",
                Description = "Toys and puzzles."
            };
            await repository.CreateAsync(category2);
            
            var category3 = new Persistence.Model.Category
            {
                Name = "Books",
                Description = "Books and publications."
            };
            await repository.CreateAsync(category3);
            */

            var persistenceModelList = await repository.GetListAsync(entity => true);
            var domainModelList = mapper.Map<IEnumerable<Domain.Model.Category>>(persistenceModelList);

            return domainModelList;
        }

        public async Task CreateCategoryAsync(Domain.Model.Category entity)
        {
            var persistenceModel = mapper.Map<Persistence.Model.Category>(entity);
            await repository.CreateAsync(persistenceModel);
        }
    }
}
