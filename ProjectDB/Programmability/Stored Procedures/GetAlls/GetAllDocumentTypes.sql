CREATE PROCEDURE [dbo].[GetAllDocumentTypes]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[DocumentTypes]
END
GO
