CREATE PROCEDURE [dbo].[GetFlightByAirplaneId]
    @AirplaneId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
    WHERE AirplaneId = @AirplaneId
END
GO
