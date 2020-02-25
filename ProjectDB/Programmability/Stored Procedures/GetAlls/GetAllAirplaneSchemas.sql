CREATE PROCEDURE [dbo].[GetAllAirplaneSchemas]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
END
GO
