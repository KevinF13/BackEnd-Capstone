using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace backend_codisecurity.Models
{
    public class Usuarios
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Id_rol { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; } = null!;

        public string apellido { get; set; }

        public string email { get; set; } = null!;

        public string password { get; set; } = null!;
        public string estado { get; set; } = null!;
    }
}
