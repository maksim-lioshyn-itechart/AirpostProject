CREATE PROCEDURE [dbo].[GetAllAirplaneSchema]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
END
GO
