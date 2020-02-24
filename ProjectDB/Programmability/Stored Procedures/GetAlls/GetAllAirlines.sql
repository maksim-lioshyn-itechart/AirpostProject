CREATE PROCEDURE [dbo].[GetAllAirlines]
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL]
    FROM [dbo].[Airlines]
END
GO
