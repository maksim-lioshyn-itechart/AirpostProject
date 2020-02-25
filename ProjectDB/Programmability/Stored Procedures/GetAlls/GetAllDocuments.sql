CREATE PROCEDURE [dbo].[GetAllDocuments]
AS
BEGIN
    SELECT [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
END
GO
