using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface IRequestDelegator
    {
        Task<TResult> DelegateAsync<TRequest, TResult>(TRequest request);
    }
}