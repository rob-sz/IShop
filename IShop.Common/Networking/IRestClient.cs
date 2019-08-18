using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public interface IRestClient
    {
        string ServiceName { get; }
        Task<T> GetAsync<T>(string requestUri, dynamic requestModel);
        Task SendAsync<TRequest>(string requestUri, TRequest requestModel);
    }
}