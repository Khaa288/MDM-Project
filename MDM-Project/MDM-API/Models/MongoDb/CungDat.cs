using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MDM_API.Models.MongoDb
{
    public class CungDat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? DiaDiem1 { get; set; }
        public string? DiaDiem2 { get; set; }

        [BsonElement("CungDat")]
        public int Times { get; set; }
    }
}
