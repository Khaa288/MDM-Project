using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using MDM_API.Models;
using MDM_API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        public async Task<ActionResult> RecommendTrip (
            string userId, 
            bool isRecommend1 = false, 
            bool isRecommend2 = false, 
            bool isRecommend3 = false
        )
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

            var recommendedTripIds = new List<string>();

            if (isRecommend1) {
                neo4j_RECOMMENDATION1.ForEach(value => recommendedTripIds.Add(value["cx"].As<string>()));
            }

            else if (isRecommend2) {
                neo4j_RECOMMENDATION2.ForEach(value => recommendedTripIds.AddRange(value["cx"].As<List<string>>()));
            }

            else if (isRecommend3) {
                neo4j_RECOMMENDATION3.ForEach(value => recommendedTripIds.Add(value["cx"].As<string>()));
            }

            else {
                neo4j_RECOMMENDATION1.ForEach(value => recommendedTripIds.Add(value["cx"].As<string>()));
                neo4j_RECOMMENDATION2.ForEach(value => recommendedTripIds.AddRange(value["cx"].As<List<string>>()));
                neo4j_RECOMMENDATION3.ForEach(value => recommendedTripIds.Add(value["cx"].As<string>()));
            }
            
            // Convert TripIds to Trips and Locations
            var neo4j_RECOMMENDED_TRIPS = await _session.RunAsync(TripQueries.GET_TRIP_WITH_LOCATIONS, new { chuyenXes = recommendedTripIds}).Result.ToListAsync();

            return Ok(neo4j_RECOMMENDED_TRIPS.Map());
        }
    }
}
