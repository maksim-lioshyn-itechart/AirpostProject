using System;

namespace PresentationAPILayer.Models
{
    public class AirportVm : BaseVm
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
