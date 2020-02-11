USE [Airport]
GO

INSERT INTO [dbo].[Roles]
            ([Name])
     VALUES ('ADMIN')
GO

INSERT INTO [dbo].[Roles]
            ([Name])
     VALUES ('AUTHORIZEDUSER')
GO

/**********************  Countries  **********************/
INSERT INTO [dbo].[Countries]
            ([Name], [Code])
     VALUES ('BARBADOS', 'BB')
GO

INSERT INTO [dbo].[Countries]
            ([Name], [Code])
     VALUES ('BOSNIA AND HERZEGOVINA', 'BA')
GO

INSERT INTO [dbo].[Countries]
            ([Name], [Code])
     VALUES ('FRENCH SOUTHERN TERRITORIES', 'TF')
GO

INSERT INTO [dbo].[Countries]
            ([Name], [Code])
     VALUES ('GERMANY', 'DE')
GO

INSERT INTO [dbo].[Countries]
            ([Name], [Code])
     VALUES ('HEARD ISLAND AND MCDONALD ISLANDS', 'HM')
GO