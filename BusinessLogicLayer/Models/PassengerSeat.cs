using System;

namespace BusinessLogicLayer.Models
{
    public class PassengerSeat : BaseModel
    {
        public Guid AirplaneSchemaId { get; set; }
        public Guid ClassTypeId { get; set; }
        public string Sector { get; set; }
        public int? Floor { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public int CoordinateX1 { get; set; }
        public int CoordinateY1 { get; set; }
        public int CoordinateX2 { get; set; }
        public int CoordinateY2 { get; set; }
    }
}
