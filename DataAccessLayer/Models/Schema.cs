using System;

namespace DataAccessLayer.Models
{
    public class Schema : BasicModel
    {
        public string Code { get; set; }
        public Guid AirPlaneId { get; set; }
        public Guid PlaceId { get; set; }
        public bool IsActive { get; set; } = false;
        public decimal Price { get; set; } = 0;
        public int PlaceNumber { get; set; }
    }
}
