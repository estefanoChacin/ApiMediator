using MongoDB.Bson.Serialization.Attributes;

namespace ApiMediator.Domain.Model
{
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRequired]
        public string Name { get; set; } = string.Empty;
        [BsonRequired]
        public string Description { get; set; } = string.Empty;
    }
}