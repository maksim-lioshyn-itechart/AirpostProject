CREATE PROCEDURE [dbo].[GetAllFlights]
AS
BEGIN
    SELECT [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
END
GO
