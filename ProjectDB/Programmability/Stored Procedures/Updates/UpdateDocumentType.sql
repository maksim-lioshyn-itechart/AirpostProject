CREATE PROCEDURE [dbo].[UpdateDocumentType]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50)
AS
BEGIN
    UPDATE [dbo].[DocumentTypes]
    SET
        [Name] = @Name
WHERE Id = @Id
END
GO
