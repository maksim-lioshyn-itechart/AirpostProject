CREATE PROCEDURE [dbo].[GetAirlineById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL], [CountryId]
    FROM [dbo].[Airlines]
    WHERE Id = @Id
END
GO
