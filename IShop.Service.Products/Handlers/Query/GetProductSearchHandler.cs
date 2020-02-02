using IShop.Common.Messaging.Query;
using IShop.Service.Products.Messages.Query;
using IShop.Service.Products.Persistence;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductSearchHandler
        : IQueryHandler<GetProductSearchQuery, GetProductSearchResult>
    {
        private readonly IProductRepository repository;

        public GetProductSearchHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetProductSearchResult> HandleAsync(GetProductSearchQuery query)
        {
            return new GetProductSearchResult
            {
                Products = await repository.GetProductsAsync(query.Category, query.Keyword)
            };
        }
    }
}
