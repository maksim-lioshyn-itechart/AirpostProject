CREATE PROCEDURE [dbo].[GetFlightBy]
    @AirplaneId UNIQUEIDENTIFIER = NULL,
    @DestinationAirportId UNIQUEIDENTIFIER = NULL,
    @DepartureAirportId UNIQUEIDENTIFIER = NULL
AS
BEGIN
    SELECT [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
    WHERE [AirplaneId] = COALESCE(@AirplaneId, [AirplaneId])
        AND [DestinationAirportId] = COALESCE(@DestinationAirportId, [DestinationAirportId])
        AND [DepartureAirportId] = COALESCE(@DepartureAirportId, [DepartureAirportId])
END
GO
