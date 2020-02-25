CREATE PROCEDURE [dbo].[DeleteAirplaneSubType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[AirplaneSubTypes] WHERE Id = @Id
END
GO
