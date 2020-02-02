using AutoMapper;
using IShop.Common.Expressions.Extensions;
using IShop.Common.Mongo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper mapper;
        private readonly IMongoDbRepository<Persistence.Model.Product> repository;

        public ProductRepository(
            IMapper mapper,
            IMongoDbRepository<Persistence.Model.Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<Domain.Model.Product> GetProductAsync(Guid id)
        {
            var persistenceModel = await repository.GetAsync(entity => entity.Id == id);
            var domainModel = mapper.Map<Domain.Model.Product>(persistenceModel);

            return domainModel;
        }

        public async Task<IEnumerable<Domain.Model.Product>> GetProductsAsync(
            string category, string keyword)
        {
            Expression<Func<Persistence.Model.Product, bool>> predicate = null;
            if (!string.IsNullOrEmpty(category))
            {
                predicate = predicate.And(entity =>
                    entity.Category.Name.ToLower().Contains(category.ToLower()));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                predicate = predicate.And(entity =>
                    entity.Name.ToLower().Contains(keyword.ToLower()) ||
                    entity.Description.ToLower().Contains(keyword.ToLower()));
            }

            var persistenceModelList = predicate == null 
                ? new List<Persistence.Model.Product>() : await repository.GetListAsync(predicate);
            var domainModelList = mapper.Map<IEnumerable<Domain.Model.Product>>(persistenceModelList);

            return domainModelList;
        }

        public async Task CreateProductAsync(Domain.Model.Product entity)
        {
            var persistenceModel = mapper.Map<Persistence.Model.Product>(entity);
            await repository.CreateAsync(persistenceModel);
        }
    }
}
