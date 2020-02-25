CREATE PROCEDURE [dbo].[GetCountryById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [Name], [Code]
    FROM [dbo].[Countries]
    WHERE Id = @Id
END
GO
