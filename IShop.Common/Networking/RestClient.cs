using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public class RestClient : IRestClient
    {
        private readonly Regex uriTokenRegex = new Regex(@"(?<=\{)[^}]*(?=\})");
        private readonly HttpClient httpClient;
        public string ServiceName { get; }

        public RestClient(HttpClient httpClient, string serviceName)
        {
            this.httpClient = httpClient;
            ServiceName = serviceName;
        }

        public async Task<TResult> GetAsync<TResult>(
            string requestUri, dynamic requestModel)
        {
            var result = await GetAsync(requestUri, requestModel);

            return await result.Content.ReadAsAsync<TResult>();
        }

        public async Task<HttpResponseMessage> GetAsync(
            string requestUri, dynamic requestModel)
        {
            var requestUriBuilder = new StringBuilder(requestUri);
            var requestModelType = requestModel.GetType();

            foreach (Match match in uriTokenRegex.Matches(requestUri))
            {
                var tokenName = match.Value;
                var tokenValue = requestModelType.GetProperty(tokenName).GetValue(requestModel);
                requestUriBuilder.Replace(
                    string.Format("{{{0}}}", tokenName),
                    WebUtility.UrlEncode(tokenValue.ToString()));
            }

            // todo! think about how to handle errors or null content here

            return await httpClient.GetAsync(requestUriBuilder.ToString());
        }

        public async Task SendAsync<TRequest>(string requestUri, TRequest requestModel)
        {
            await httpClient.PostAsync(requestUri, new StringContent(
                JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json"));
        }
    }
}
