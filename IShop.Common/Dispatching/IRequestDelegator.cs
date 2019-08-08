using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface IRequestDelegator
    {
        Task<TResult> Delegate<TRequest, TResult>(TRequest request);
    }
}