CREATE PROCEDURE [dbo].[GetAllClassTypes]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[ClassTypes]
END
GO
