CREATE TABLE [dbo].[Schemas]
(
    [Id] INT NOT NULL , 
    [AirPlaneId] UNIQUEIDENTIFIER NOT NULL, 
    [PlaceId] UNIQUEIDENTIFIER NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [Price] MONEY NULL, 
    [PlaceNumber] INT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Schemas_Airplanes] FOREIGN KEY ([AirPlaneId]) REFERENCES Airplanes([Id]), 
    CONSTRAINT [FK_Schemas_Places] FOREIGN KEY ([PlaceId]) REFERENCES Places([Id])
)
