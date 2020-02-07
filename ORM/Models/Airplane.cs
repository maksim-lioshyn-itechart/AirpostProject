using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Airplane: BasicModel
    {
        public string Type { get; set; }
        public double CarryingCapacity { get; set; }
        public double OverWeightPrice { get; set; }
        public double FreeWeightPrice { get; set; }
    }
}
