using System.Threading.Tasks;

namespace IShop.Common.Messaging.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(IQuery query);
    }
}
