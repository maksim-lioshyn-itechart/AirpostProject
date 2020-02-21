CREATE PROCEDURE [dbo].[InsertDocumentType]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50)
AS
BEGIN
    INSERT INTO [dbo].[DocumentTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
