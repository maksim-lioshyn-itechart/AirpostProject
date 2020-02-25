CREATE PROCEDURE [dbo].[GetTicketById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [UserId], [OrderStatusId], [FlightId], [PassengerSeatId], [DocumentId], [TicketNumber], [PurchaseDate], [BaggageCount], [Cost], [Taxes], [FreeWeightCapacity], [OverweightPrice], [Total]
    FROM [dbo].[Tickets]
    WHERE Id = @Id
END
GO
