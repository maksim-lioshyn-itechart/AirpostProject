﻿CREATE TABLE [dbo].[Users] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Users_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [FirstName] NVARCHAR (300)   NOT NULL,
    [LastName]  NVARCHAR (300)   NOT NULL,
    [Login]     NVARCHAR (50)    NOT NULL,
    [Password]  NVARCHAR (50)    NOT NULL,
    [RoleId]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([id]) ON DELETE SET NULL,
    CONSTRAINT [IX_UsersLogin] UNIQUE NONCLUSTERED ([Id] ASC)
);

