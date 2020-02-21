CREATE PROCEDURE [dbo].[GetByIdAirline]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name], [Email], [Phone], [Address], [URL]
    FROM [dbo].[Airlines]
    WHERE Id = @Id
END
GO
