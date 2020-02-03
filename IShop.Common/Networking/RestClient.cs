using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient httpClient;
        public string ServiceName { get; }

        public RestClient(HttpClient httpClient, string serviceName)
        {
            this.httpClient = httpClient;
            ServiceName = serviceName;
        }

        public async Task<TResult> GetAsync<TResult>(string requestUri, params object[] requestUriValues)
        {
            var result = await httpClient.GetAsync(string.Format(requestUri, requestUriValues));

            return await result.Content.ReadAsAsync<TResult>();
        }

        public async Task SendAsync<TRequest>(string requestUri, TRequest requestModel)
        {
            await httpClient.PostAsync(requestUri, new StringContent(
                JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json"));
        }
    }
}
