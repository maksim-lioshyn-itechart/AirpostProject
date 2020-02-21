CREATE PROCEDURE [dbo].[InsertDocument]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50),
    @Number nvarchar(50),
    @DocumentTypeId UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO [dbo].[Documents] ([Id], [Name], [Number], [DocumentTypeId])
    VALUES(@Id, @Name, @Number, @DocumentTypeId)
END
GO
