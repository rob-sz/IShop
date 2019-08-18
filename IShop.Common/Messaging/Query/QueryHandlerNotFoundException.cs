using System;

namespace IShop.Common.Messaging.Query
{
    public class QueryHandlerNotFoundException : Exception
    {
        public IQuery Query { get; }

        public QueryHandlerNotFoundException(IQuery query)
            : base($"Query handler not found for: {nameof(query)}.")
        {
            Query = query;
        }
    }
}
