CREATE PROCEDURE [dbo].[InsertAirplaneType]
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO [dbo].[AirplaneTypes] ([Id], [Name])
    VALUES(@Id, @Name)
END
GO
