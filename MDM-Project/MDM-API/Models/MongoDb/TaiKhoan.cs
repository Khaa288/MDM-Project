using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MDM_API.Models.MongoDb
{
    public class TaiKhoan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int MaTaiKhoan { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set;}
        public string? Email { get; set; }
        public string? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? NgheNghiep { get; set; }
        public string? SDT { get; set; }
        public string? MatKhau { get; set;}
    }
}
