CREATE TABLE [dbo].[Places]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT newsequentialid(), 
    [Type] NVARCHAR(50) NOT NULL, 
    [CoordinateX1] INT NULL, 
    [CoordinateY1] INT NULL,
    [CoordinateX2] INT NULL, 
    [CoordinateY2] INT NULL, 
    CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT CHK_PlacesType CHECK ([Type] IN ('FirstClass', 'BusinessClass', 'EconomyClass', 'FirstBusinessClass', 'BusinessEconomyClass', 'PremiumEconomyClass', 'Other')),
    
)
