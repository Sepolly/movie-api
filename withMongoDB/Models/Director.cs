using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace withMongoDB.Models
{
    public class Director
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Movie> Movies { get; set; } = [];
    }
}
