CREATE PROCEDURE [dbo].[DeleteDocument]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM [dbo].[Documents] WHERE Id = @Id
END
GO
