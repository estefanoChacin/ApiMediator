
using MongoDB.Driver;

namespace ApiMediator.Domain.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}