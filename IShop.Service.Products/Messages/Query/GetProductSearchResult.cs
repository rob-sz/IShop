using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;
using System.Collections.Generic;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductSearchResult : IQueryResult
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
