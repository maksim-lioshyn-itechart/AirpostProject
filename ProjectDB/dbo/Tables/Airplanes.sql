CREATE TABLE [dbo].[Airplanes]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT (newsequentialid()), 
    [Type] NVARCHAR(150) NOT NULL, 
    [SubType] NVARCHAR(150) NOT NULL, 
    [CarryingCapacity] DECIMAL NOT NULL DEFAULT 0, 
    [OverWeightPrice] MONEY NULL DEFAULT 0,
    [FreeWeightCapacity] DECIMAL NULL DEFAULT 0, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Airplanes] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT CHK_AirplanesType CHECK (
        [Type] = 'CommercialAirplanes' AND [SubType] IN ('JumboPassengerJets', 'MidSizePassengerJets', 'LightPassengerJets', 'PassengerTurboProps', 'CargoAirplanes') OR
        [Type] = 'PrivateJets' AND [SubType] IN ('VLJ', 'LightBusinessJets', 'MidsizeBusinessJets', 'HeavyBusinessJets', 'MilitaryJets') OR
        [Type] = 'PrivatePropellorPlanes' AND [SubType] IN ('PrivateSingleEngine', 'TwinTurboprops', 'Aerobatic', 'Amphibious', 'MilitaryTurboprops')),
    
)
