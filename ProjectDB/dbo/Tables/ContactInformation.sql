CREATE TABLE [dbo].[ContactInformation] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [UserId]  UNIQUEIDENTIFIER NOT NULL,
    [Phone]   NVARCHAR (50)    NOT NULL,
    [Address] NVARCHAR (MAX)   NULL,
    [Email]   NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_ContactInformation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContactInformation_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

