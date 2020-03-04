CREATE PROCEDURE [dbo].[InsertDocument]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50),
    @Number nvarchar(50),
    @DocumentTypeId UNIQUEIDENTIFIER,
    @IsActive BIT
AS
BEGIN
    INSERT INTO [dbo].[Documents] ([Id], [Name], [Number], [DocumentTypeId], [IsActive])
    VALUES(@Id, @Name, @Number, @DocumentTypeId, @IsActive)
END
GO
