using System;

namespace DataAccessLayer.Models
{
    public class Airport : BasicModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid PlaceId { get; set; }
    }
}
