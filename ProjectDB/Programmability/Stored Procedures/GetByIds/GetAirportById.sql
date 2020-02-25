CREATE PROCEDURE [dbo].[GetAirportById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
    WHERE Id = @Id
END
GO
