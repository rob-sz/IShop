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

        // note: put in another dispatch function for dispatching to a query handler
        // note: maybe change requestUriValues to a TRequest object and have Dispatch<TRequest, TResult>
        //  then use reflection to make sure TRequest has all the right properties or something like that

        public async Task<TResult> Dispatch<TResult>(string requestUri, params object[] requestUriValues)
            => await restClient.GetAsync<TResult>(requestUri, requestUriValues);
    }
}
