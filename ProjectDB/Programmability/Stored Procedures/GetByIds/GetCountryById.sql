CREATE PROCEDURE [dbo].[GetCountryById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name], [Code]
    FROM [dbo].[Countries]
    WHERE Id = @Id
END
GO
