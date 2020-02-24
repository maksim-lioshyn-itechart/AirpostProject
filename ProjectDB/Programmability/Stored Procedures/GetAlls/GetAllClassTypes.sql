CREATE PROCEDURE [dbo].[GetAllClassTypes]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[ClassTypes]
END
GO
