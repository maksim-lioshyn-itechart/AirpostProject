CREATE PROCEDURE [dbo].[GetAirlineById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
    WHERE Id = @Id
END
GO
