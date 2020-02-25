CREATE PROCEDURE [dbo].[GetAirplaneSubTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
    WHERE Id = @Id
END
GO
