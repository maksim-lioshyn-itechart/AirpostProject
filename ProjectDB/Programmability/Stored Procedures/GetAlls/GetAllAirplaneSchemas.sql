CREATE PROCEDURE [dbo].[GetAllAirplaneSchemas]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
END
GO
