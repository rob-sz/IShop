using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;
using IShop.Service.Products.Messages.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetProductsByCategoryHandler
        : IQueryHandler<GetProductsByCategoryQuery, IEnumerable<Product>>
    {
        public Task<IEnumerable<Product>> HandleAsync(GetProductsByCategoryQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
