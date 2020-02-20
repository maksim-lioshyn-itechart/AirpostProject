CREATE PROCEDURE [dbo].[SpInsertDocumentType]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[DocumentTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO