CREATE PROCEDURE [dbo].[GetByIdFlight]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    Select [Id], [DepartureAirportId], [DestinationAirportId], [DepartureTimeUTC], [ArrivalTimeUTC], [AirplaneId]
    FROM [dbo].[Flights]
    WHERE Id = @Id
END
GO
