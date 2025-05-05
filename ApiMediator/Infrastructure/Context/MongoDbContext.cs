using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMediator.Domain.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<DatabaseSetting> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        => _database.GetCollection<T>(name);
    }
}