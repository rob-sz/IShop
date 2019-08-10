using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;

namespace IShop.Common.Networking.Extensions
{
    public static class RestClientInjection
    {
        private static string ConfigurationSectionName = "RestClient";

        public static IHttpClientBuilder AddHttpClientForService(
            this IServiceCollection services, string serviceName)
        {
            return services.AddHttpClient(serviceName, httpClient =>
            {
                var restClientSettings = GetRestClientSettings(services);
                var serviceSettings = restClientSettings.Services.SingleOrDefault(
                    s => s.Name.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
                if (serviceSettings == null)
                {
                    throw new ServiceNotFoundException(
                        $"Service '{serviceName}' settings not found.", serviceName);
                }

                httpClient.BaseAddress = new UriBuilder
                {
                    Scheme = serviceSettings.Type,
                    Host = serviceSettings.Host,
                    Port = serviceSettings.Port
                }.Uri;
            });
        }

        public static IRestClient CreateRestClient(this IServiceProvider serviceProvider, string serviceName)
        {
            return new RestClient(
                serviceProvider.GetService<IHttpClientFactory>().CreateClient(serviceName),
                serviceName);
        }

        private static RestClientSettings GetRestClientSettings(IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var configurationSection = configuration.GetSection(ConfigurationSectionName);

                services.Configure<RestClientSettings>(configurationSection);

                var restClientSettings = new RestClientSettings();
                configurationSection.Bind(restClientSettings);

                return restClientSettings;
            }
        }
    }
}
