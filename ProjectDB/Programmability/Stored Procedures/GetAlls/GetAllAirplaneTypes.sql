CREATE PROCEDURE [dbo].[GetAllAirplaneTypes]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneTypes]
END
GO
