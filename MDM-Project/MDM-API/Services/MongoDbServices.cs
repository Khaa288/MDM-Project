using MDM_API.Models.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MDM_API.Services
{
    public class MongoDbServices
    {
        private readonly IMongoCollection<TaiKhoan> _taiKhoanCollection;
        private readonly IMongoCollection<DiaDiem> _diadiemCollection;
        private readonly IMongoCollection<VeXe> _vexeCollection;
        private readonly IMongoCollection<ChuyenXe> _chuyenxeCollection;
        private readonly IMongoCollection<CungDat> _cungDatCollection;

        public MongoDbServices(IOptions<MongoDbSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.Local);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.Database);
            _taiKhoanCollection = database.GetCollection<TaiKhoan>(mongoDBSettings.Value.CollectionNames[0]);
            _diadiemCollection = database.GetCollection<DiaDiem>(mongoDBSettings.Value.CollectionNames[1]);
            _vexeCollection = database.GetCollection<VeXe>(mongoDBSettings.Value.CollectionNames[2]);
            _chuyenxeCollection = database.GetCollection<ChuyenXe>(mongoDBSettings.Value.CollectionNames[3]);
            _cungDatCollection = database.GetCollection<CungDat>(mongoDBSettings.Value.CollectionNames[4]);
        }

        // TaiKhoan Queries
        public async Task<List<TaiKhoan>> GetUsersAsync() {
            return await _taiKhoanCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TaiKhoan> GetUserByIdAsync(int id)
        {
            return await _taiKhoanCollection.Find(tk => tk.MaTaiKhoan == id).FirstOrDefaultAsync();
        }

        // DiaDiem Queries
        public async Task<List<DiaDiem>> GetLocationsAsync()
        {
            return await _diadiemCollection.Find(_ => true).ToListAsync();
        }

        // VeXe queries
        public async Task<List<VeXe>> GetUserTickets(string userId)
        {
            return await _vexeCollection.Find(vx => vx.MaTaiKhoan == userId).ToListAsync();
        }

        // ChuyenXe queries
        public async Task<List<ChuyenXe>> GetTicketsTripsAsync(List<VeXe> tickets) {
            return await _chuyenxeCollection.Find(cx => tickets.Any(t => t.MaChuyen == cx.MaChuyen)).ToListAsync();
        }

        // Recommendation queries
        public async Task<IEnumerable<object>> Recommendation1(string userId)
        {
            var recommend1 = await _vexeCollection
                        .Aggregate()
                        .Match(vx => vx.MaTaiKhoan == userId)
                        .Group(v => v.MaChuyen, r => new { MaChuyen = r.Key, SoLuong = r.Count() })
                        .SortByDescending(r => r.SoLuong)
                        .Limit(3)
                        .ToListAsync();

            return recommend1;
        }

        public async Task<List<ChuyenXe>> Recommendation2(string userId)
        {
            var tickets = await GetUserTickets(userId);
            var trips = await GetTicketsTripsAsync(tickets);
            var locations = new List<string>();
            trips.ForEach(l => locations.AddRange(l.DiaDiems!));
            locations = locations.Distinct().ToList();

            var recommend2 = await _chuyenxeCollection
                        .Find(gy => locations
                            .Any(l => gy.DiaDiems!.Contains(l) && !trips.Contains(gy) && gy.SoGheTrong != 0) // gy DiaDiem is location DiaDiem and gy is not trips
                        ) 
                        .Limit(10)
                        .ToListAsync();

            return recommend2;
        }

        public async Task<List<ChuyenXe>> Recommendation3 ()
        {
            var maxCungDat = await _cungDatCollection.Find(_ => true).SortByDescending(cd => cd.Times).FirstOrDefaultAsync();
            var trips = await _chuyenxeCollection
                        .Find(gy => 
                            gy.DiaDiems!.Contains(maxCungDat.DiaDiem1!) && 
                            gy.DiaDiems!.Contains(maxCungDat.DiaDiem2!) &&
                            gy.SoGheTrong != 0
                        ) 
                        .Limit(3)
                        .ToListAsync();

            return trips;
        }
    }
}
