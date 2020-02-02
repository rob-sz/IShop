using IShop.Common.Messaging.Query;
using IShop.Service.Products.Messages.Query;
using IShop.Service.Products.Persistence;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductCategoriesHandler 
        : IQueryHandler<GetProductCategoriesQuery, GetProductCategoriesResult>
    {
        private readonly ICategoryRepository repository;

        public GetProductCategoriesHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetProductCategoriesResult> HandleAsync(GetProductCategoriesQuery query)
        {
            return new GetProductCategoriesResult
            {
                Categories = await repository.GetCategoriesAsync()
            };
        }
    }
}
