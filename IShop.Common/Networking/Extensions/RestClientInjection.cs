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

        public static IServiceCollection AddRestClient(
            this IServiceCollection services, string serviceName)
        {
            ConfigureRestClient(services, serviceName);

            return services.AddTransient(
                serviceProvider => serviceProvider.GetRestClient(serviceName));
        }

        public static IRestClient GetRestClient(
            this IServiceProvider serviceProvider, string serviceName)
        {
            return new RestClient(
                serviceProvider.GetService<IHttpClientFactory>().CreateClient(serviceName));
        }

        private static void ConfigureRestClient(IServiceCollection services, string serviceName)
        {
            services.AddHttpClient(serviceName, client =>
            {
                var restClientSettings = GetRestClientSettings(services);
                var serviceSettings = restClientSettings.Services.SingleOrDefault(
                    s => s.Name.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
                if (serviceSettings == null)
                {
                    throw new ServiceNotFoundException(
                        $"Service '{serviceName}' settings not found.", serviceName);
                }

                client.BaseAddress = new UriBuilder
                {
                    Scheme = serviceSettings.Type,
                    Host = serviceSettings.Host,
                    Port = serviceSettings.Port
                }.Uri;
            });
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
