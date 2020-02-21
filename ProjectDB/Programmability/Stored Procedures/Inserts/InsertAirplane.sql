CREATE PROCEDURE [dbo].[InsertAirplane]
    @Id UNIQUEIDENTIFIER,
    @AirplaneSubTypeId UNIQUEIDENTIFIER,
    @AirplaneTypeId UNIQUEIDENTIFIER,
    @AirplaneSchemaId UNIQUEIDENTIFIER,
    @AirlineId UNIQUEIDENTIFIER,
    @Name NVARCHAR(50),
    @CarryingCapacity DECIMAL
AS
BEGIN
    SET @Id = NEWID();
    INSERT INTO [dbo].[Airplanes] ([Id], [AirplaneSubTypeId], [AirplaneTypeId], [AirplaneSchemaId], [AirlineId], [Name], [CarryingCapacity])
    VALUES(@Id, @AirplaneSubTypeId, @AirplaneTypeId, @AirplaneSchemaId, @AirlineId, @Name, @CarryingCapacity)
END
GO
