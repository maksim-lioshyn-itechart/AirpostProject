CREATE PROCEDURE [dbo].[UpdateAirplane]
    @Id UNIQUEIDENTIFIER,
    @AirplaneSubTypeId UNIQUEIDENTIFIER,
    @AirplaneTypeId UNIQUEIDENTIFIER,
    @AirplaneSchemaId UNIQUEIDENTIFIER,
    @AirlineId UNIQUEIDENTIFIER,
    @Name NVARCHAR(50),
    @CarryingCapacity DECIMAL
AS
BEGIN
    UPDATE [dbo].[Airplanes]
    SET
        [AirplaneSubTypeId] = @AirplaneSubTypeId,
        [AirplaneTypeId] = @AirplaneTypeId,
        [AirplaneSchemaId] = @AirplaneSchemaId,
        [AirlineId] = @AirlineId,
        [Name] = @Name,
        [CarryingCapacity] = @CarryingCapacity
WHERE Id = @Id
END
GO
