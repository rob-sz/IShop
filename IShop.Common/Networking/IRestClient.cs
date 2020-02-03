using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public interface IRestClient
    {
        string ServiceName { get; }
        Task<TResult> GetAsync<TResult>(string requestUri, params object[] requestUriValues);
        Task SendAsync<TRequest>(string requestUri, TRequest requestModel);
    }
}