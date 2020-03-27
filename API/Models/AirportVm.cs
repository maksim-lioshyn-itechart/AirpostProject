using System;

namespace API.Models
{
    public class AirportViewModel : BaseViewModel
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
