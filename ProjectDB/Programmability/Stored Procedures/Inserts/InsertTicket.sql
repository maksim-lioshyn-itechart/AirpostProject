CREATE PROCEDURE [dbo].[InsertTicket]
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
    SET @Id = NEWID();
    INSERT INTO [dbo].[Tickets] ([Id], [UserId], [OrderStatusId], [FlightId], [PassengerSeatId], [DocumentId], [TicketNumber], [PurchaseDate], [BaggageCount], [Cost], [Taxes], [FreeWeightCapacity], [OverweightPrice], [Total])
    VALUES(@Id, @UserId, @OrderStatusId, @FlightId, @PassengerSeatId, @DocumentId, @TicketNumber, @PurchaseDate, @BaggageCount, @Cost, @Taxes, @FreeWeightCapacity, @OverweightPrice, @Total)
END
GO
