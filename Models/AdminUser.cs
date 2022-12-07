using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVC_WebApplication.Models
{
    [BsonIgnoreExtraElements]
    public class AdminUser
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("password")]
        public string? Password { get; set; } = string.Empty;

    }
}
