using IShop.Common.Messaging.Query;
using IShop.Service.Products.Messages.Query;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductSearchHandler
        : IQueryHandler<GetProductSearchQuery, GetProductSearchResult>
    {
        public async Task<GetProductSearchResult> HandleAsync(GetProductSearchQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
