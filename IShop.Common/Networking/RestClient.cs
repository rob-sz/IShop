using IShop.Common.Dispatching;
using Microsoft.AspNetCore.Routing.Template;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient httpClient;

        public RestClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TResult> GetAsync<TResult>(
            string requestUri, params object[] requestUriValues)
        {
            var routeTemplate = TemplateParser.Parse(requestUri);
            if (routeTemplate.Parameters.Count != requestUriValues.Length)
                throw new ArgumentException("Request URI parameters do not match values.");

            var resultUri = new StringBuilder(requestUri);
            for (int i = 0; i < routeTemplate.Parameters.Count; i++)
            {
                resultUri.Replace(
                    string.Format("{{{0}}}", routeTemplate.Parameters[i].Name),
                    WebUtility.UrlEncode(requestUriValues[i].ToString()));
            }
            requestUri = resultUri.ToString();

            var response = await httpClient.GetAsync(requestUri);
            return await response.Content.ReadAsAsync<TResult>();
        }
    }
}
