CREATE PROCEDURE [dbo].[GetByIdAirplaneType]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [Name]
    FROM [dbo].[AirplaneTypes]
    WHERE Id = @Id
END
GO
