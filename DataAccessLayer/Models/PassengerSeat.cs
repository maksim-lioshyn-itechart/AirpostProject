using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class PassengerSeat: BasicModel
    {
        public Guid PassengerSeatTemplateId { get; set; }
        public Guid ClassTypeId { get; set; }
        public string Sector { get; set; }
        public int? Floor { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
    }
}
