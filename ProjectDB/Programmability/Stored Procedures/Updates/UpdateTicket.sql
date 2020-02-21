CREATE PROCEDURE [dbo].[UpdateTicket]
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @OrderStatusId UNIQUEIDENTIFIER,
    @FlightId UNIQUEIDENTIFIER,
    @PassengerSeatId UNIQUEIDENTIFIER,
    @DocumentId UNIQUEIDENTIFIER,
    @TicketNumber NVARCHAR(20),
    @PurchaseDate DATETIME,
    @BaggageCount INT,
    @Cost MONEY,
    @Taxes MONEY,
    @FreeWeightCapacity DECIMAL,
    @OverweightPrice MONEY,
    @Total MONEY
AS
BEGIN
    UPDATE [dbo].[Tickets]
    SET
        [UserId] = @UserId,
        [OrderStatusId] = @OrderStatusId,
        [FlightId] = @FlightId,
        [PassengerSeatId] = @PassengerSeatId,
        [DocumentId] = @DocumentId,
        [TicketNumber] = @TicketNumber,
        [PurchaseDate] = @PurchaseDate,
        [BaggageCount] = @BaggageCount,
        [Cost] = @Cost,
        [Taxes] = @Taxes,
        [FreeWeightCapacity] = @FreeWeightCapacity,
        [OverweightPrice] = @OverweightPrice,
        [Total] = @Total
    WHERE Id = @Id
END
GO
