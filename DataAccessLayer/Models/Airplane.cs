using System;

namespace DataAccessLayer.Models
{
    public class Airplane : BaseModel
    {
        public Guid AirplaneSubTypeId { get; set; }
        public Guid AirplaneTypeId { get; set; }
        public Guid AirplaneSchemaId { get; set; }
        public Guid AirlineId { get; set; }
        public string Name { get; set; }
        public decimal CarryingCapacity { get; set; }
    }
}
