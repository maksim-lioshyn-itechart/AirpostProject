CREATE PROCEDURE [dbo].[GetAllAirports]
AS
BEGIN
    Select [Id], [CountryId], [Name], [IsActive]
    FROM [dbo].[Airports]
END
GO
