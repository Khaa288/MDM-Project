using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using MDM_API.Utilities;

namespace MDM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAsyncSession _session;

        public AuthController(IAsyncSession session)
        {
            _session = session;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var users = await _session.RunAsync(AuthQueries.GET_USERS);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var result = await _session.RunAsync(AuthQueries.LOGIN, new {username, password});
            var user = await result.ToListAsync();

            if (user.Count > 0)
            {
                return Ok(user);
            }

            return BadRequest(NotFound("Invalid Email or Password"));
        }
    }
}
