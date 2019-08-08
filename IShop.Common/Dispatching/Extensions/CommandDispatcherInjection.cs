using Microsoft.Extensions.DependencyInjection;

namespace IShop.Common.Dispatching.Extensions
{
    public static class CommandDispatcherInjection
    {
        public static void AddCommandDispatcher<TSender>(
            this IServiceCollection services, string serviceName) where TSender : class
        {
            //services.AddTransient<IQueryDispatcher<TSender>>(serviceProvider =>
            //    new CommandDispatcher<TSender>(serviceProvider.GetRestClient(serviceName)));
        }
    }
}
