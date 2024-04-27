using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MDM_API.Models.MongoDb
{
    public class VeXe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? MaTaiKhoan { get; set; }
        public string? MaChuyen { get; set; }
        public int MaHoaDon { get; set; }
        public string? MaDatVe  { get; set; }
        public string? ThoiGian { get; set; }
        public string? TrangThai { get; set; }
        public string? DiemLenXe { get; set; }
        public float TongTien { get; set; }
        public int SoGhe { get; set; }
    }
}
