
using ApiMediator.Domain.Interfaces;
using MongoDB.Driver;

namespace ApiMediator.Infrastructure.Repository
{
    public class DBRepository<T>(IMongoDbContext mongoDbContext) : IDBRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection = mongoDbContext.GetCollection<T>(typeof(T).Name) ?? throw new ArgumentNullException(nameof(mongoDbContext), "MongoDbContext cannot be null.");

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
            =>  await _collection.Find(_ => true).ToListAsync();
        

        public async Task<T> GetByIdAsync(string id)
            => await _collection.Find( Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();


        public async Task RemoveAsync(string id)
            => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        

        public async Task<T> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.ReplaceOneAsync(filter, entity);
            return entity;
        }
    }
}