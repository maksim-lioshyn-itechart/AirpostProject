CREATE PROCEDURE [dbo].[DeleteAirline]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[Airlines] WHERE Id = @Id
END
GO
