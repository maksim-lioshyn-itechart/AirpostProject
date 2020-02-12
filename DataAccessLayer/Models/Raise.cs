using System;

namespace DataAccessLayer.Models
{
    public class Raise : BasicModel
    {
        public string Name { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid DestinationAirportId { get; set; }
        public DateTime Sortie { get; set; }
    }
}
