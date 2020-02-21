CREATE PROCEDURE [dbo].[UpdateAirplaneType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[AirplaneTypes]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
