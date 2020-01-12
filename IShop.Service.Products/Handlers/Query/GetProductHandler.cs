using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;
using IShop.Service.Products.Messages.Query;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductHandler
        : IQueryHandler<GetProductQuery, Product>
    {
        public Task<Product> HandleAsync(GetProductQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
