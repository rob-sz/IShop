using IShop.Common.Messaging.Query;
using IShop.Service.Products.Messages.Query;
using IShop.Service.Products.Persistence;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductHandler
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        private readonly IProductRepository repository;

        public GetProductHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetProductResult> HandleAsync(GetProductQuery query)
        {
            var result = new GetProductResult
            {
                Product = await repository.GetProductAsync(query.Id)
            };

            return result;
        }
    }
}
