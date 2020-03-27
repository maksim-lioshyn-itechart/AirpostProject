using System;

namespace DataAccess.Models
{
    public class FlightEntity : BaseEntity
    {
        public Guid DepartureAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public DateTime DepartureTimeUtc { get; set; }
        public DateTime ArrivalTimeUtc { get; set; }
        public Guid AirplaneId { get; set; }
    }
}
