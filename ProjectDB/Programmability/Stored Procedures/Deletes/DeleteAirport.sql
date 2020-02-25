CREATE PROCEDURE [dbo].[DeleteAirport]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[Airports] WHERE Id = @Id
END
GO
