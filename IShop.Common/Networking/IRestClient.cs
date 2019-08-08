using System.Threading.Tasks;

namespace IShop.Common.Networking
{
    public interface IRestClient
    {
        Task<T> GetAsync<T>(string requestUri, params object[] requestUriValues);
    }
}