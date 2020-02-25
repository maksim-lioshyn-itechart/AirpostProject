CREATE PROCEDURE [dbo].[DeleteAirplaneType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[AirplaneTypes] WHERE Id = @Id
END
GO
