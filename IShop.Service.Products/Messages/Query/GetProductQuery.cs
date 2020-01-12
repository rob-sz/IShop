using IShop.Common.Messaging.Query;
using System;

namespace IShop.Service.Products.Messages.Query
{
    public class GetProductQuery : IQuery
    {
        public Guid Id { get; }

        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
