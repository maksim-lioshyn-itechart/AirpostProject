CREATE PROCEDURE [dbo].[GetAllCountries]
AS
BEGIN
    SELECT [Id], [Name], [Code]
    FROM [dbo].[Countries]
END
GO
