CREATE PROCEDURE [dbo].[GetAllAirplaneType]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneTypes]
END
GO
