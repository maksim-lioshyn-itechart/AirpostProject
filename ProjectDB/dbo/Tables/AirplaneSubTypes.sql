﻿CREATE TABLE [dbo].[AirplaneSubTypes]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_AirplaneSubTypes_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [AirplaneTypeId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_AirplaneSubTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AirplaneSubTypes_AirplaneTypes] FOREIGN KEY ([AirplaneTypeId]) REFERENCES AirplaneTypes([Id]), 
)
