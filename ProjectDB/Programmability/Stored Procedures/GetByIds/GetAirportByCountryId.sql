CREATE PROCEDURE [dbo].[GetAirportByCountryId]
    @CountryId UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
    WHERE CountryId = @CountryId
END
GO
