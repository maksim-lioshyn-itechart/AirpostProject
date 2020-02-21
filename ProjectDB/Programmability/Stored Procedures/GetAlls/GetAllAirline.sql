CREATE PROCEDURE [dbo].[GetAllAirline]
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL]
    FROM [dbo].[Airlines]
END
GO
