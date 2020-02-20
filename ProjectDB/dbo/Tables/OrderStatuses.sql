CREATE TABLE [dbo].[OrderStatuses]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_OrderStatuses_Id] DEFAULT (newid()) NOT NULL,
    [Name] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED ([Id] ASC),
)
