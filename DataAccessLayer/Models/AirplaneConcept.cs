using System;

namespace DataAccessLayer.Models
{
    public class AirplaneConcept: BasicModel
    {
        public Guid AirplaneTypeId { get; set; }
        public string Name { get; set; }
    }
}
