CREATE PROCEDURE [dbo].[GetByIdDocumentType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[DocumentTypes]
    WHERE Id = @Id
END
GO
