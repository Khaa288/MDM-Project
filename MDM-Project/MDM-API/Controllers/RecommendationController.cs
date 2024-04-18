using MDM_API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace MDM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IAsyncSession _session;

        public RecommendationController(IAsyncSession session)
        {
            _session = session;
        }

        [HttpGet]
        public async Task<ActionResult> RecommendTrip (string userId)
        {
            var recommendTrips = new List<IRecord>();

            var neo4j_RECOMMENDATION1 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION1, new { maTaiKhoan = userId });
            var neo4j_RECOMMENDATION2 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION2, new { maTaiKhoan = userId });
            var neo4j_RECOMMENDATION3 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION3);

            return Ok(neo4j_RECOMMENDATION2);
        }
    }
}
