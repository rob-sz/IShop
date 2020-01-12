using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;
using IShop.Service.Products.Messages.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetCategoriesHandler 
        : IQueryHandler<GetCategoriesQuery, IEnumerable<ProductCategory>>
    {
        public Task<IEnumerable<ProductCategory>> HandleAsync(GetCategoriesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
