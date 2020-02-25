using System;

namespace BusinessLogicLayer.Models
{
    public class FlightBm : BaseBm
    {
        public Guid DepartureAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public DateTime DepartureTimeUtc { get; set; }
        public DateTime ArrivalTimeUtc { get; set; }
        public Guid AirplaneId { get; set; }
    }
}
