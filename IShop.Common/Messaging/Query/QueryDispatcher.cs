using System;
using System.Threading.Tasks;

namespace IShop.Common.Messaging.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> DispatchAsync<TResult>(IQuery query)
        {
            var queryHandlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            var queryHandler =
                serviceProvider.GetService(queryHandlerType)
                    as IQueryHandler<IQuery, TResult>;
            if (queryHandler == null)
                throw new QueryHandlerNotFoundException(query);

            return await queryHandler.HandleAsync(query);
        }
    }
}
