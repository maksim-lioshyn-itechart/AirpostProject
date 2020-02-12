CREATE TABLE [dbo].[Raises]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [DepartureAirportId] UNIQUEIDENTIFIER NOT NULL, 
    [DestinationAirportId] UNIQUEIDENTIFIER NOT NULL, 
    [Sortie] DATETIME NULL
)
