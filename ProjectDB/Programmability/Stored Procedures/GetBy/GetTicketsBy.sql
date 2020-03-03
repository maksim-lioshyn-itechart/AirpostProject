CREATE PROCEDURE [dbo].[GetTicketsBy]
    @TicketNumber NVARCHAR(10) = NULL
AS
BEGIN
    SELECT [Id], [UserId], [OrderStatusId], [FlightId], [PassengerSeatId], [DocumentId], [TicketNumber], [PurchaseDate], [BaggageCount], [Cost], [Taxes], [FreeWeightCapacity], [OverweightPrice], [Total]
    FROM [dbo].[Tickets]
    WHERE [TicketNumber] = COALESCE(@TicketNumber, [TicketNumber])
END
GO
