CREATE PROCEDURE [dbo].[GetAllAirline]
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
END
GO
