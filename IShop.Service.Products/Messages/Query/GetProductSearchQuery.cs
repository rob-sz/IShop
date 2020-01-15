using IShop.Common.Messaging.Query;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductSearchQuery : IQuery
    {
        public string Category { get; set; }
        public string Keyword { get; set; }
    }
}
