using System;

namespace BusinessLogic.Models
{
    public class Ticket : BaseModel
    {
        public Guid? UserId { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerSeatId { get; set; }
        public Guid DocumentId { get; set; }
        public string TicketNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int BaggageCount { get; set; }
        public decimal Cost { get; set; }
        public decimal Taxes { get; set; }
        public decimal FreeWeightCapacity { get; set; }
        public decimal OverWeightPrice { get; set; }
        public decimal Total { get; set; }
    }
}
