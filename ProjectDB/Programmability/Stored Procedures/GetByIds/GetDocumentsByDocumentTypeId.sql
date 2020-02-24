CREATE PROCEDURE [dbo].[GetDocumentsByDocumentTypeId]
    @DocumentTypeId UNIQUEIDENTIFIER,
    @IsActive BIT = NULL
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
    WHERE DocumentTypeId = @DocumentTypeId AND IsActive = COALESCE(@IsActive, IsActive)
END
GO
