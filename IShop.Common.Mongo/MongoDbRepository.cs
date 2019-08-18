using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Common.Mongo
{
    public class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity>
    {
        protected IMongoCollection<TEntity> Collection { get; }

        public MongoDbRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();

        public async Task CreateAsync(TEntity entity)
            => await Collection.InsertOneAsync(entity);
    }
}
