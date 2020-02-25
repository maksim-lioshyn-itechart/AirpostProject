CREATE PROCEDURE [dbo].[GetAirplaneTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneTypes]
    WHERE Id = @Id
END
GO
