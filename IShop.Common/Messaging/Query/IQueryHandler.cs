using System.Threading.Tasks;

namespace IShop.Common.Messaging.Query
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
