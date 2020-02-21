CREATE PROCEDURE [dbo].[InsertAirplaneSchema]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    INSERT INTO [dbo].[AirplaneSchemas] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
