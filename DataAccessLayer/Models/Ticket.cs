using System;

namespace DataAccessLayer.Models
{
    public class Ticket : BasicModel
    {
        public Guid UserId { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid RaiseId { get; set; }
        public Guid PassengerSeatId { get; set; }
        public Guid DocumentId { get; set; }
        public string TicketNumber { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int Baggage { get; set; }
        public decimal Cost { get; set; }
        public decimal Taxes { get; set; }
        public decimal FreeWeightCapacity { get; set; }
        public decimal OverWeightPrice { get; set; }
    }
}
