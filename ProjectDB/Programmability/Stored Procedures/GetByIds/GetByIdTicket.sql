CREATE PROCEDURE [dbo].[GetByIdTicket]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [UserId], [OrderStatusId], [FlightId], [PassengerSeatId], [DocumentId], [TicketNumber], [PurchaseDate], [BaggageCount], [Cost], [Taxes], [FreeWeightCapacity], [OverweightPrice], [Total]
    FROM [dbo].[Tickets]
    WHERE Id = @Id
END
GO
