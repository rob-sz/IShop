using IShop.Common.Networking.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.Common.Dispatching.Extensions
{
    public static class QueryDispatcherInjection
    {
        public static IServiceCollection AddQueryDispatcher<TSender>(
            this IServiceCollection services, string serviceName) where TSender : class
        {
            services.AddHttpClientForService(serviceName);

            return services.AddTransient<IQueryDispatcher<TSender>>(serviceProvider =>
                new QueryDispatcher<TSender>(serviceProvider.CreateRestClient(serviceName)));
        }
    }
}
