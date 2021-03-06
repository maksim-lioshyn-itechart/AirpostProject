﻿CREATE TABLE [dbo].[UserPasswords]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_UserPasswords_Id] DEFAULT (newid()) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Salt] BINARY(16) NOT NULL,
    [Hash] BINARY(32) NOT NULL,
    CONSTRAINT [PK_UserPasswords] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPasswords_ Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
)
