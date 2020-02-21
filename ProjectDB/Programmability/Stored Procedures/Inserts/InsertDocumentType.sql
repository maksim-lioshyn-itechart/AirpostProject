CREATE PROCEDURE [dbo].[InsertDocumentType]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[DocumentTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
