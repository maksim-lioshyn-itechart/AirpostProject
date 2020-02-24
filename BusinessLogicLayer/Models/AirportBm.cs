using System;

namespace BusinessLogicLayer.Models
{
    public class AirportBm : BaseBm
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
