using System;

namespace DataAccessLayer.Models
{
    public class Ticket: BasicModel
    {
        public Guid UserId { get; set; }
        public Guid RaiseId { get; set; }
        public string TicketNumber { get; set; }
        public string Document { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Guid ClassTypeId { get; set; }
        public int Baggage { get; set; }
        public decimal Fare { get; set; }
        public decimal Taxes { get; set; }
        public decimal Charge { get; set; }
        public decimal FreeWeightCapacity { get; set; }
        public decimal OverWeightPrice { get; set; }
        public string Seat { get; set; }
        public Guid OrderStatusId { get; set; }
	}
}
