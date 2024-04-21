namespace MDM_API.Models
{
    public class TripResponse
    {
        public string TripId { get; set; }
        public string VehicleType { get; set;}
        public string JourneyType { get; set;}
        public string EmptySeats { get; set;}
        public string StartTime { get; set;}
        public string ArrivedTime { get; set;}
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
    }
}
