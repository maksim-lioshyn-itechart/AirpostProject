using System;

namespace DataAccessLayer.Models
{
    public class AirplaneSchema : BasicModel
    {
        public Guid AirplaneId { get; set; }
        public int NumberOfSeats { get; set; }
        public string Code { get; set; }
    }
}
