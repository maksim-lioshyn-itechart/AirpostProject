using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Document: BasicModel
    {
        public Guid DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
