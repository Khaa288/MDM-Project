using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MDM_API.Models.MongoDb
{
    public class DiaDiem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int MaDiaDiem { get; set; }
        public string? TenDiaDiem { get; set; }
    }
}
