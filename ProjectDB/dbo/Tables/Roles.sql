﻿CREATE TABLE [dbo].[Roles] (
    [id]   UNIQUEIDENTIFIER CONSTRAINT [DF_Roles_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_RolesName] UNIQUE NONCLUSTERED ([id] ASC)
);
