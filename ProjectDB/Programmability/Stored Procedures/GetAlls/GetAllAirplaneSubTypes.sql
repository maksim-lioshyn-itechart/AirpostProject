CREATE PROCEDURE [dbo].[GetAllAirplaneSubTypes]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
END
GO
