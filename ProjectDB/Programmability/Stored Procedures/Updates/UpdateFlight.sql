CREATE PROCEDURE [dbo].[UpdateFlight]
    @Id UNIQUEIDENTIFIER,
    @DepartureAirportId UNIQUEIDENTIFIER,
    @DestinationAirportId UNIQUEIDENTIFIER,
    @DepartureTimeUTC DATETIME,
    @ArrivalTimeUTC DATETIME,
    @AirplaneId UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE [dbo].[Flights]
    SET
        [DepartureAirportId] = @DepartureAirportId,
        [DestinationAirportId] = @DestinationAirportId,
        [DepartureTimeUTC] = @DepartureTimeUTC,
        [ArrivalTimeUTC] = @ArrivalTimeUTC,
        [AirplaneId] = @AirplaneId
    WHERE Id = @Id
END
GO
