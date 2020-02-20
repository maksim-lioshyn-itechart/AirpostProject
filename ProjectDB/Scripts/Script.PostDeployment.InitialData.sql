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
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'UserRoles')
    IF (SELECT COUNT([dbo].[UserRoles].[Name]) FROM [dbo].[UserRoles]) = 0
        BEGIN
            INSERT INTO [dbo].[UserRoles] ([Name]) VALUES ('ADMIN')
            INSERT INTO [dbo].[UserRoles] ([Name]) VALUES ('AUTHORIZEDUSER')
        END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Countries')
    IF (SELECT COUNT([dbo].[Countries].[Name]) FROM [dbo].[Countries]) = 0
        BEGIN
            INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('BARBADOS', 'BB')
            INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('BOSNIA AND HERZEGOVINA', 'BA')
            INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('FRENCH SOUTHERN TERRITORIES', 'TF')
            INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('GERMANY', 'DE')
            INSERT INTO [dbo].[Countries] ([Name], [Code]) VALUES ('HEARD ISLAND AND MCDONALD ISLANDS', 'HM')
        END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AirplaneTypes')
    IF (SELECT COUNT([dbo].[AirplaneTypes].[Name]) FROM [dbo].[AirplaneTypes]) = 0
        BEGIN
            INSERT INTO [dbo].[AirplaneTypes] ([Name]) VALUES ('CommercialAirplanes')
            INSERT INTO [dbo].[AirplaneTypes] ([Name]) VALUES ('PrivateJets')
            INSERT INTO [dbo].[AirplaneTypes] ([Name]) VALUES ('PrivatePropellorPlanes')
        END


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AirplaneSubTypes')
    IF (SELECT COUNT([dbo].[AirplaneSubTypes].[Name]) FROM [dbo].[AirplaneSubTypes]) = 0
        BEGIN
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Jumbo Passenger Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('MidSize Passenger Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Light Passenger Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Passenger Turbo Props')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Cargo Airplanes')

            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('VLJ')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Light Business Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Midsize Business Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Heavy Business Jets')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Military Jets')

            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Private Single Engine')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Twin Turboprops')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Aerobatic')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Amphibious')
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name]) VALUES ('Military Turboprops')
        END


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ClassTypes')
    IF (SELECT COUNT([dbo].[ClassTypes].[Name]) FROM [dbo].[ClassTypes]) = 0
        BEGIN
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('First Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Business Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Economy Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Other')
        END
