﻿using Microsoft.Extensions.DependencyInjection;
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
            where TResult : IQueryResult
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var queryHandlerType = typeof(IQueryHandler<,>)
                    .MakeGenericType(query.GetType(), typeof(TResult));

                dynamic queryHandler =
                    scope.ServiceProvider.GetService(queryHandlerType);

                if (queryHandler == null)
                    throw new QueryHandlerNotFoundException(query);

                return await queryHandler.HandleAsync((dynamic)query);
            }
        }
    }
}
