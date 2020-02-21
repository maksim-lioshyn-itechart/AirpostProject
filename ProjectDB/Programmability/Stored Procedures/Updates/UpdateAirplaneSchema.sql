CREATE PROCEDURE [dbo].[UpdateAirplaneSchema]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    UPDATE [dbo].[AirplaneSchemas]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
