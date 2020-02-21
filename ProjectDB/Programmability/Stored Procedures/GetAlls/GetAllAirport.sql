CREATE PROCEDURE [dbo].[GetAllAirport]
AS
BEGIN
    Select [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
END
GO
