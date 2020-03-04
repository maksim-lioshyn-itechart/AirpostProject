CREATE PROCEDURE [dbo].[GetClassTypeBy]
    @Name NVARCHAR(50) = NULL
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[ClassTypes]
    WHERE [Name] = COALESCE(@Name, [Name])
END
GO
