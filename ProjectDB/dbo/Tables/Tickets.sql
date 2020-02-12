CREATE TABLE [dbo].[Tickets]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NULL, 
    [RaiseId] UNIQUEIDENTIFIER NOT NULL, 
    [PlaceType] NCHAR(50) NOT NULL, 
    [Cost] MONEY NOT NULL DEFAULT 0, 
    [Number] INT NOT NULL, 
    CONSTRAINT [CK_Tickets_PlaceType] CHECK ([PlaceType] IN ('FirstClass', 'BusinessClass', 'EconomyClass', 'FirstBusinessClass', 'BusinessEconomyClass', 'PremiumEconomyClass', 'Other')), 
)
