using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MDM_API.Models.MongoDb
{
    public class ChuyenXe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? MaChuyen { get; set; }
        public string? LoaiXe { get; set; }
        public string? LoaiHanhTrinh { get; set; }

        [BsonRepresentation(BsonType.String)]
        public int SoGheTrong { get; set; }
        public string? ThoiGianKhoiHanh { get; set; }
        public string? ThoiGianDen { get; set; }
        public List<string>? DiaDiems { get; set; }
    }
}
