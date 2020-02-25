CREATE PROCEDURE [dbo].[GetDocumentById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name], [Number], [DocumentTypeId]
    FROM [dbo].[Documents]
    WHERE Id = @Id
END
GO
