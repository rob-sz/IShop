using IShop.Common.Messaging.Query;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductsByCategoryQuery : IQuery
    {
        public string Category { get; set; }
    }
}
