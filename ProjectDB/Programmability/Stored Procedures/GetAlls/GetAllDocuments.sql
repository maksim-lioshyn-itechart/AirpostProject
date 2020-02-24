CREATE PROCEDURE [dbo].[GetAllDocuments]
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId]
    FROM [dbo].[Documents]
END
GO
