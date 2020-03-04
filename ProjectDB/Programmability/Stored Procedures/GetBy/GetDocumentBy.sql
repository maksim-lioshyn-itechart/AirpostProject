CREATE PROCEDURE [dbo].[GetDocumentBy]
    @DocumentTypeId UNIQUEIDENTIFIER = NULL,
    @Name NVARCHAR(50) = NULL,
    @Number NVARCHAR(50) = NULL,
    @IsActive BIT = NULL
AS
BEGIN
    SELECT [Id], [Name], [Number], [DocumentTypeId], [IsActive]
    FROM [dbo].[Documents]
    WHERE [DocumentTypeId] = COALESCE(@DocumentTypeId, [DocumentTypeId])
        AND [IsActive] = COALESCE(@IsActive, [IsActive])
        AND [Name] = COALESCE(@Name, [Name])
        AND [Number] = COALESCE(@Number, [Number])
END
GO
