using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class SchemasPassengerSeatTemplate: BasicModel
    {
        public Guid PassengerSeatTemplateId { get; set; }
        public Guid AirplaneSchemaId { get; set; }
    }
}
