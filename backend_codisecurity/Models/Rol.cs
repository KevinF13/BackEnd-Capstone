using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace backend_codisecurity.Models
{
    public class Rol
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre_rol")]
        public string nombre_rol { get; set; } = null!;
        public string estado { get; set; } = null!;
    }
}
