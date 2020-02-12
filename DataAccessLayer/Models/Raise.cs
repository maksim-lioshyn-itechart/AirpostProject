using System;

namespace DataAccessLayer.Models
{
    public class Raise : BasicModel
    {
        public Guid DepartureAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public DateTime Sortie { get; set; }
    }
}
