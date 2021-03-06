CREATE PROCEDURE [dbo].[GetDocumentTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[DocumentTypes]
    WHERE Id = @Id
END
GO
