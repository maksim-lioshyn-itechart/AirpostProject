CREATE PROCEDURE [dbo].[GetAllDocuments]
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
END
GO
