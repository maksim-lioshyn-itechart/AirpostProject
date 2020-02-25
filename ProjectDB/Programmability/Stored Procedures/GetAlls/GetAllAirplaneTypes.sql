CREATE PROCEDURE [dbo].[GetAllAirplaneTypes]
AS
BEGIN
    SELECT [Id], [Name]
    FROM [dbo].[AirplaneTypes]
END
GO
