﻿CREATE TABLE [dbo].[UserContactInformation] (
    [Id]      UNIQUEIDENTIFIER NOT NULL DEFAULT newsequentialid(),
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [Phone]   NVARCHAR (50)    NOT NULL,
    [Address] NVARCHAR (MAX)   NULL,
    [Email]   NVARCHAR (256)   NULL,
    CONSTRAINT [PK_UserContactInformation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserContactInformation_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

