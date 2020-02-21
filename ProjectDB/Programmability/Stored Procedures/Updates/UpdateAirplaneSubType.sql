CREATE PROCEDURE [dbo].[UpdateAirplaneSubType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[AirplaneSubTypes]
    SET
        [Name] = @Name
    WHERE Id = @Id
END
GO
