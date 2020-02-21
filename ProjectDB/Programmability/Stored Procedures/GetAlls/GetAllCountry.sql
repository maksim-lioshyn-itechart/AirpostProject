CREATE PROCEDURE [dbo].[GetAllCountry]
AS
BEGIN
    Select [Id], [Name], [Code]
    FROM [dbo].[Countries]
END
GO
