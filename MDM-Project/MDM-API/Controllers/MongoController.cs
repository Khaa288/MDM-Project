using MDM_API.Models.MongoDb;
using MDM_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MDM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly MongoDbServices _mongoServices;

        public MongoController(MongoDbServices mongoServices)
        {
            _mongoServices = mongoServices;
        }

        [HttpGet("recommend1")]
        public async Task<IEnumerable<object>> Recommendation1(string userId)
        {
            return await _mongoServices.Recommendation1(userId);
        }

        [HttpGet("recommend2")]
        public async Task<List<ChuyenXe>> Recommendation2(string userId)
        {
            return await _mongoServices.Recommendation2(userId);
        }

        [HttpGet("recommend3")]
        public async Task<List<ChuyenXe>> Recommendation3 ()
        {
            return await _mongoServices.Recommendation3 ();
        }

        [HttpGet("recommend")]
        public async Task Recommendation(string userId)
        {
            await _mongoServices.Recommendation1(userId);
            await _mongoServices.Recommendation2(userId);
            await _mongoServices.Recommendation3();
        }
    }
}
