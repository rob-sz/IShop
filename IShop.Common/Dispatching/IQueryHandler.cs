using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public interface IQueryHandler<TRequest, TResult>
    {
        Task<TResult> HandleAsync(TRequest request);
    }
}
