CREATE PROCEDURE [dbo].[GetAllAirports]
AS
BEGIN
    SELECT [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
END
GO
