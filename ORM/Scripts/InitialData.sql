USE [Airport]
GO

INSERT INTO [dbo].[Roles]
            ([id],[Name])
     VALUES (CAST('00000000-0000-0000-0000-000000000000' AS uniqueidentifier), 'ADMIN')
GO

INSERT INTO [dbo].[Roles]
            ([id],[Name])
     VALUES (CAST('00000000-0000-0000-0000-000000000001' AS uniqueidentifier), 'AUTHORIZEDUSER')
GO