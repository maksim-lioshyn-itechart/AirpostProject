CREATE PROCEDURE [dbo].[GetAllClassType]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[ClassTypes]
END
GO
