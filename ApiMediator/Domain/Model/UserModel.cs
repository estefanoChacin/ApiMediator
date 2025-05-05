using MongoDB.Bson.Serialization.Attributes;

namespace ApiMediator.Infrastructure.Model
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRequired]
        public string UserName { get; set; } = string.Empty;
        [BsonRequired]
        public string Password { get; set; } = string.Empty;
        [BsonRequired]
        public string Email { get; set; } = string.Empty;
        [BsonRequired]
        public string ProductLastFour { get; set; } = string.Empty;
    }
}