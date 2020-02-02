using IShop.Common.Networking.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace IShop.Common.Messaging.Extensions
{
    public static class ServiceBrokerInjection
    {
        public static IServiceCollection AddServiceBroker<TSender>(
            this IServiceCollection services, string serviceName) where TSender : class
        {
            services.AddHttpClientForService(serviceName);
            services.AddTransient(serviceProvider => serviceProvider.CreateRestClient(serviceName));

            return services.AddSingleton<IServiceBroker<TSender>, ServiceBroker<TSender>>();
        }
    }
}
