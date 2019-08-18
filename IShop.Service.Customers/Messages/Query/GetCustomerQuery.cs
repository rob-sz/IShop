using IShop.Common.Messaging.Query;
using System;

namespace IShop.Service.Customers.Messages.Query
{
    public class GetCustomerQuery : IQuery
    {
        public Guid Id { get; }

        public GetCustomerQuery(Guid id)
        {
            Id = id;
        }
    }
}
