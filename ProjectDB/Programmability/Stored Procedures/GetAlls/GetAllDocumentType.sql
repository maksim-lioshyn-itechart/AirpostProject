CREATE PROCEDURE [dbo].[GetAllDocumentType]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[DocumentTypes]
END
GO
