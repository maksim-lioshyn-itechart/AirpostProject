CREATE TABLE [dbo].[AirplaneTypes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_TypeAirplanes_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_AirplaneTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
)
