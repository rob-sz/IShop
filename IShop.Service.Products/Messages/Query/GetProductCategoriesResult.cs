using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;
using System.Collections.Generic;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductCategoriesResult : IQueryResult
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
