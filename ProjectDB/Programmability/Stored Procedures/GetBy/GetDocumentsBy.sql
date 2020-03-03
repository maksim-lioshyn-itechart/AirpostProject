CREATE PROCEDURE [dbo].[GetDocumentsBy]
    @DocumentTypeId UNIQUEIDENTIFIER = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SELECT [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
    WHERE DocumentTypeId = COALESCE(@DocumentTypeId, DocumentTypeId)
        AND IsActive = COALESCE(@IsActive, IsActive)
END
GO
