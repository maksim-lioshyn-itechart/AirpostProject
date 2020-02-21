CREATE PROCEDURE [dbo].[DeleteCountry]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[Countries] WHERE Id = @Id
END
GO
