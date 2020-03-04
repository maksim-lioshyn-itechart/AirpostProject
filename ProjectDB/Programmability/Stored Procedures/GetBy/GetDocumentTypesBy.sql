CREATE PROCEDURE [dbo].[GetDocumentTypesBy]
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[DocumentTypes]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
