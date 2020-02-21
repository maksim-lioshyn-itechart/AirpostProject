CREATE PROCEDURE [dbo].[GetAllAirplaneSubType]
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
END
GO
