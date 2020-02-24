CREATE PROCEDURE [dbo].[GetDocumentById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId]
    FROM [dbo].[Documents]
    WHERE Id = @Id
END
GO
