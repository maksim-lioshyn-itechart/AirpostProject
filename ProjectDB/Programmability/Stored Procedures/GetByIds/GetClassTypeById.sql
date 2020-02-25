CREATE PROCEDURE [dbo].[GetClassTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[ClassTypes]
    WHERE Id = @Id
END
GO
