/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Roles')
BEGIN
    INSERT INTO [dbo].[Roles] ([Name]) VALUES ('ADMIN')

    INSERT INTO [dbo].[Roles] ([Name]) VALUES ('AUTHORIZEDUSER')
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Countries')
BEGIN
INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('BARBADOS', 'BB')

INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('BOSNIA AND HERZEGOVINA', 'BA')

INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('FRENCH SOUTHERN TERRITORIES', 'TF')

INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('GERMANY', 'DE')

INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('HEARD ISLAND AND MCDONALD ISLANDS', 'HM')
END