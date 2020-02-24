CREATE PROCEDURE [dbo].[GetAllAirplaneSubTypes]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
END
GO
