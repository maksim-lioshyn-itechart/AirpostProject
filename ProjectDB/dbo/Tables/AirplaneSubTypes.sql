CREATE TABLE [dbo].[AirplaneSubTypes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_AirplaneSubTypes_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_AirplaneSubTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
)
