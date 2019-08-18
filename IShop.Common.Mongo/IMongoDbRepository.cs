using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Common.Mongo
{
    public interface IMongoDbRepository<TEntity>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity entity);
    }
}