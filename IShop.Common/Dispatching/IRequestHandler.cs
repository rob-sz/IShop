using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface IRequestHandler<TRequest, TResult>
    {
        Task<TResult> HandleAsync(TRequest request);
    }
}
