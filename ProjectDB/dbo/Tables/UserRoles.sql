﻿CREATE TABLE [dbo].[UserRoles] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_UserRoles_Id] DEFAULT newid() NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_UserRolesName] UNIQUE NONCLUSTERED ([Name] ASC)
);
