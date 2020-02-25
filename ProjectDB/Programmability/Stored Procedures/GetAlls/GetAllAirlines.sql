CREATE PROCEDURE [dbo].[GetAllAirlines]
AS
BEGIN
    SELECT [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
END
GO
