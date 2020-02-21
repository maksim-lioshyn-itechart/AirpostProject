CREATE PROCEDURE [dbo].[InsertAirplaneSchema]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR (50)
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[AirplaneSchemas] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
