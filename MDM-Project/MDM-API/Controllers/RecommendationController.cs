using MDM_API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Neo4j.Driver.Preview.Mapping;

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
            var neo4j_RECOMMENDATION1 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION1, new { maTaiKhoan = userId }).Result.ToListAsync();
            var neo4j_RECOMMENDATION2 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION2, new { maTaiKhoan = userId }).Result.ToListAsync();

            var neo4j_getMostFrequentOrderAlongLocations = await _session.RunAsync(RecommendationQueries.GET_MOST_FREQUENT_ORDER_ALONG_LOCATIONS);
            var locations = neo4j_getMostFrequentOrderAlongLocations.ToListAsync()
                                                .Result
                                                .Select(value =>
                                                {
                                                    return new
                                                    {
                                                        maDiaDiem1 = value["dd1"].As<INode>().Properties["MaDiaDiem"].As<string>(),
                                                        maDiaDiem2 = value["dd2"].As<INode>().Properties["MaDiaDiem"].As<string>()
                                                    };
                                                })
                                                .Single();
            var neo4j_RECOMMENDATION3 = await _session.RunAsync(RecommendationQueries.RECOMMENDATION3, locations).Result.ToListAsync();

            var recommendedTrips = neo4j_RECOMMENDATION1
                                        .Concat(neo4j_RECOMMENDATION2)
                                        .Concat(neo4j_RECOMMENDATION3);

            return Ok(recommendedTrips);
        }
    }
}
