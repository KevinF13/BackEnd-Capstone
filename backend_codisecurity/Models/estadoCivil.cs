using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace backend_codisecurity.Models
{
    public class estadoCivil
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null!;

        [BsonElement("nombre")]
        public string nombre { get; set; } = null!;

        public string estado { get; set; } = null!;
    }
}
