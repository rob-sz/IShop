using System.Threading.Tasks;

namespace IShop.Common.Messaging
{
    public interface IServiceBroker<TSender> where TSender : class
    {
        Task<TResult> ReceiveAsync<TResult>(string requestUri, params object[] requestUriValues);
        Task SendAsync<TRequest>(string requestUri, TRequest requestModel);
    }
}