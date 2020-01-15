using System.Threading.Tasks;

namespace IShop.Common.Messaging.Query
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TResult : IQueryResult
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
