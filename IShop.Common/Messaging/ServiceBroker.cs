using IShop.Common.Networking;
using System.Threading.Tasks;

namespace IShop.Common.Messaging
{
    public class ServiceBroker<TSender>
        : IServiceBroker<TSender> where TSender : class
    {
        private readonly IRestClient restClient;

        public ServiceBroker(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public async Task<TResult> ReceiveAsync<TResult>(string requestUri, params object[] requestUriValues)
            => await restClient.GetAsync<TResult>(requestUri, requestUriValues);

        public async Task SendAsync<TRequest>(string requestUri, TRequest requestModel)
            => await restClient.SendAsync(requestUri, requestModel);
    }
}
