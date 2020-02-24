CREATE PROCEDURE [dbo].[UpdateDocument]
    @Id UNIQUEIDENTIFIER,
    @Name nvarchar(50),
    @Number nvarchar(50),
    @DocumentTypeId UNIQUEIDENTIFIER,
    @IsActive BIT
AS
BEGIN
    UPDATE [dbo].[Documents]
    SET
        [Name] = @Name,
        [Number] = @Number,
        [DocumentTypeId] = @DocumentTypeId,
        [IsActive] = @IsActive
    WHERE Id = @Id
END
GO
