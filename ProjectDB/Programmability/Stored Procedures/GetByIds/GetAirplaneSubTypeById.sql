CREATE PROCEDURE [dbo].[GetAirplaneSubTypeById]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSubTypes]
    WHERE Id = @Id
END
GO
