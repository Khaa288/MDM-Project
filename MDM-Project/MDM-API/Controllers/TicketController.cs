using MDM_API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace MDM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IAsyncSession _session;

        public TicketController(IAsyncSession session)
        {
            _session = session;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var result = await _session.RunAsync(TicketQueries.GET_ALL_TICKETS);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> BookTicket(string userId, string ticketId, string tripId, int seatNumber)
        {
            #region Location Queries
            var neo4j_TicketLocations = await _session.RunAsync(TripQueries.GET_TRIP_LOCATIONS, new { maChuyen = tripId });

            var locations = neo4j_TicketLocations
                                                .ToListAsync()
                                                .Result
                                                .Select(value =>
                                                {
                                                    return value["dd"].As<INode>().Properties["MaDiaDiem"].As<string>();
                                                });

            var locationsRelationshipParams = new { diemDi = locations.Last(), diemDen = locations.First() };
            await _session.RunAsync(LocationQueries.UPDATE_LOCATIONS_RELATIONSHIP, locationsRelationshipParams);
            #endregion

            #region Ticket Queries
            var createTicketParams = new { maDatVe = ticketId, date = DateTime.Now, soGhe = seatNumber };
            var ticketTripRelationshipParams = new { maChuyen = tripId, maDatVe = ticketId };
            var userTicketRelationshipParams = new { maTaiKhoan = userId, maDatVe = ticketId };

            await _session.RunAsync(TicketQueries.CREATE_TICKET, createTicketParams);
            await _session.RunAsync(TicketQueries.CREATE_TICKET_TRIP_RELATIONSHIP, ticketTripRelationshipParams);
            await _session.RunAsync(TicketQueries.CREATE_USER_TICKET_RELATIONSHIP, userTicketRelationshipParams);
            #endregion

            #region Trip Queries
            // Update Seat Quantity
            var neo4j_GetTrip = await _session
                                            .RunAsync(TripQueries.GET_TRIP, new { maChuyen = tripId })
                                            .Result
                                            .SingleAsync();

            var remainedSeats = neo4j_GetTrip["cx"]
                                            .As<INode>()
                                            .Properties["SoGheTrong"]
                                            .As<int>() - seatNumber;

            var updateTicketSeatQuantityParams = new { maChuyen = tripId, soGheConLai = remainedSeats };
            await _session.RunAsync(TripQueries.UPDATE_TRIP_SEAT_QUANTITY, updateTicketSeatQuantityParams);

            // Update User --> Trip 
            var getTripUserRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
            var neo4j_GetTripUserRelationship = await _session
                                            .RunAsync(TripQueries.GET_TRIP_USER_RELATIONSHIP, getTripUserRelationshipParams)
                                            .Result
                                            .SingleAsync();
            var relationshipExists = neo4j_GetTripUserRelationship["exists"].As<int>();

            if (relationshipExists > 0)
            {
                var updateUserTripRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
                await _session.RunAsync(TripQueries.UPDATE_TRIP_USER_RELATIONSHIP, updateUserTripRelationshipParams);
            }

            else
            {
                var createUserTripRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
                await _session.RunAsync(TripQueries.CREATE_TRIP_USER_RELATIONSHIP, createUserTripRelationshipParams);
            }

            #endregion

            return Ok();
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var tripId = "32";
            var userId = "4";
            var getTripUserRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
            var neo4j_GetTripUserRelationship = await _session.RunAsync(TripQueries.GET_TRIP_USER_RELATIONSHIP, getTripUserRelationshipParams).Result.SingleAsync();
            var relationshipExists = neo4j_GetTripUserRelationship["exists"].As<int>();

            if (relationshipExists > 0)
            {
                var updateUserTripRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
                await _session.RunAsync(TripQueries.UPDATE_TRIP_USER_RELATIONSHIP, updateUserTripRelationshipParams);
            }

            else
            {
                var createUserTripRelationshipParams = new { maChuyen = tripId, maTaiKhoan = userId };
                await _session.RunAsync(TripQueries.CREATE_TRIP_USER_RELATIONSHIP, createUserTripRelationshipParams);
            }

            return Ok();
        }
    }
}
