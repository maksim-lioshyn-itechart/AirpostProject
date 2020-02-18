using System;

namespace DataAccessLayer.Models
{
    public class Airplane : BasicModel
    {
        public Guid AirplaneConceptId { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AirplaneSchemaId { get; set; }
        public string Name { get; set; }
        public decimal CarryingCapacity { get; set; }
    }
}
