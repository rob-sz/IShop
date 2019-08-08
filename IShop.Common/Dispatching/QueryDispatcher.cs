using IShop.Common.Networking;
using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public class QueryDispatcher<TSender> 
        : IQueryDispatcher<TSender> where TSender : class
    {
        private IRestClient restClient;

        public QueryDispatcher(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public async Task<TResult> Dispatch<TResult>(string requestUri, params object[] requestUriValues)
            => await restClient.GetAsync<TResult>(requestUri, requestUriValues);
    }
}
