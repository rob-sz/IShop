using IShop.Common.Messaging.Query;
using IShop.Service.Products.Domain.Model;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductResult : IQueryResult
    {
        public Product Product { get; set; }
    }
}
