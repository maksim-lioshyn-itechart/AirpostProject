CREATE PROCEDURE [dbo].[DeleteDocumentType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
   DELETE FROM [dbo].[DocumentTypes] WHERE Id = @Id
END
GO
