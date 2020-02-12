using DataAccessLayer.Enums;

namespace DataAccessLayer.Models
{
    public class Airplane : BasicModel
    {
        public AirplaneType Type { get; set; }
        public AirplaneSubType SubType { get; set; }
        public double CarryingCapacity { get; set; } = 0;
        public double OverWeightPrice { get; set; } = 0;
        public double FreeWeightCapacity { get; set; } = 0;
    }
}
