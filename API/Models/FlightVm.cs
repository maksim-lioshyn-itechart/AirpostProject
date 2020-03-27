using System;

namespace API.Models
{
    public class FlightViewModel : BaseViewModel
    {
        public Guid DepartureAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public DateTime DepartureTimeUtc { get; set; }
        public DateTime ArrivalTimeUtc { get; set; }
        public Guid AirplaneId { get; set; }
    }
}
