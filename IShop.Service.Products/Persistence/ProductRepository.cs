using AutoMapper;
using IShop.Common.Mongo;
using IShop.Service.Products.Persistence.Model;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Products.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper mapper;
        private readonly IMongoDbRepository<Product> repository;

        public ProductRepository(
            IMapper mapper,
            IMongoDbRepository<Product> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<Domain.Model.Product> GetAsync(Guid id)
        {
            var persistenceModel = await repository.GetAsync(product => product.Id == id);
            var domainModel = Map(persistenceModel);

            return domainModel;
        }

        private Product Map(Domain.Model.Product product)
        {
            return mapper.Map<Product>(product);
        }

        private Domain.Model.Product Map(Product product)
        {
            return mapper.Map<Domain.Model.Product>(product);
        }
    }
}
