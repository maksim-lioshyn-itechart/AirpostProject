CREATE PROCEDURE [dbo].[DeleteAirplaneSchema]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[AirplaneSchemas] WHERE Id = @Id
END
GO
