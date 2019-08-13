using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface IQueryDispatcher<TSender> where TSender : class
    {
        Task<TResult> DispatchAsync<TResult>(string requestUri, dynamic requestModel);
    }
}
