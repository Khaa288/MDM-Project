using Microsoft.AspNetCore.Http;
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
    }
}
