CREATE PROCEDURE [dbo].[SpInsertAirplaneSchema]
    @Name NVARCHAR (50),
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[AirplaneSchemas] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO