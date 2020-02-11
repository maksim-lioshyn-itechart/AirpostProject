using DataAccessLayer.Enums;

namespace DataAccessLayer.Models
{
    public class Airplane: BasicModel
    {
        public AirplaneType Type { get; set; }
        public AirplaneSubType SubType { get; set; }
        public double CarryingCapacity { get; set; }
        public double OverWeightPrice { get; set; }
        public double FreeWeightPrice { get; set; }
    }
}
