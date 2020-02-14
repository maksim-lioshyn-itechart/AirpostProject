using System;

namespace DataAccessLayer.Models
{
    public class Airplane : BasicModel
    {
		public string Name { get; set; }
        public Guid AirplaneTypeId { get; set; }
        public Guid AirplaneSubTypeId { get; set; }
        public decimal CarryingCapacity { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AirplaneSchemaId { get; set; }
	}
}
