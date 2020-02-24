CREATE PROCEDURE [dbo].[GetClassTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[ClassTypes]
    WHERE Id = @Id
END
GO
