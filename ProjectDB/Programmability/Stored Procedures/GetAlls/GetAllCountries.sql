CREATE PROCEDURE [dbo].[GetAllCountries]
AS
BEGIN
    Select [Id], [Name], [Code]
    FROM [dbo].[Countries]
END
GO
