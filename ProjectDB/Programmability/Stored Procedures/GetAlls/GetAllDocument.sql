CREATE PROCEDURE [dbo].[GetAllDocument]
AS
BEGIN
    Select [Id], [Name], [Number], [DocumentTypeId]
    FROM [dbo].[Documents]
END
GO
