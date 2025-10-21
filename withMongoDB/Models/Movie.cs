using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace withMongoDB.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int Year { get; set; }
        public float Rating { get; set; }
        public string Director { get; set; } = null!;

    }

}
