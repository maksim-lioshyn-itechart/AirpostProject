CREATE PROCEDURE [dbo].[GetDocumentById]
    @Id UNIQUEIDENTIFIER,
    @IsActive BIT = NULL
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
    WHERE Id = @Id AND IsActive = COALESCE(@IsActive, IsActive)
END
GO
