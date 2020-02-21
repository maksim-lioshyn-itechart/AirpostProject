CREATE PROCEDURE [dbo].[GetAllTicket]
AS
BEGIN
    Select [Id], [UserId], [OrderStatusId], [FlightId], [PassengerSeatId], [DocumentId], [TicketNumber], [PurchaseDate], [BaggageCount], [Cost], [Taxes], [FreeWeightCapacity], [OverweightPrice], [Total]
    FROM [dbo].[Tickets]
END
GO
