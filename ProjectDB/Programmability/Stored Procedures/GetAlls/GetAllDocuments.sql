CREATE PROCEDURE [dbo].[GetAllDocuments]
AS
BEGIN
    SELECT [Id], [Name], [Number], [DocumentTypeId]
    FROM [dbo].[Documents]
END
GO
