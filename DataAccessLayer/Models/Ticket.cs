using System;
using DataAccessLayer.Enums;

namespace DataAccessLayer.Models
{
    public class Ticket : BasicModel
    {
        public int Number { get; set; }
        public Guid UserId { get; set; }
        public Guid RaiseId { get; set; }
        public PlaceType PlaceType { get; set; }
        public double Cost { get; set; }
    }
}
