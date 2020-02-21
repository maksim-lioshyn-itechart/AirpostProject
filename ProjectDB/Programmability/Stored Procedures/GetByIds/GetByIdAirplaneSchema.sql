CREATE PROCEDURE [dbo].[GetByIdAirplaneSchema]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneSchemas]
    WHERE Id = @Id
END
GO
