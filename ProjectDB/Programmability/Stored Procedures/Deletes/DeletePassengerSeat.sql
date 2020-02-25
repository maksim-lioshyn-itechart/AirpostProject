CREATE PROCEDURE [dbo].[DeletePassengerSeat]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[PassengerSeats] WHERE Id = @Id
END
GO
