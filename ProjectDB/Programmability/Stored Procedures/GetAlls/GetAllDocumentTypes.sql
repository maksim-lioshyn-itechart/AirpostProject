CREATE PROCEDURE [dbo].[GetAllDocumentTypes]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[DocumentTypes]
END
GO
