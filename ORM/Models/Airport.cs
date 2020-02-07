using ORM.Attributes;
using System;

namespace ORM.Models
{
    [AirportTable(Name = "Airports")]
    public class Airport : BasicModel
    {
        [AirportColumn(Name = "Name")]
        public string Name { get; set; }
        [AirportColumn(Name = "IsActive")]
        public bool IsActive { get; set; }
        [AirportColumn(Name = "CountryId")]
        public Guid CountryId { get; set; }
    }
}
