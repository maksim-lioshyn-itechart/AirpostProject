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
Declare  @AirplaneTypeCommercialAirplaneId uniqueidentifier;
Declare  @AirplaneTypePrivateJetId uniqueidentifier;
Declare  @AirplaneTypePrivatePropellorPlaneId uniqueidentifier;
Set @AirplaneTypeCommercialAirplaneId = CAST(newid() AS uniqueidentifier)
Set @AirplaneTypePrivateJetId = CAST(newid() AS uniqueidentifier)
Set @AirplaneTypePrivatePropellorPlaneId = CAST(newid() AS uniqueidentifier)

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
            INSERT INTO [dbo].[AirplaneTypes] ([Id], [Name]) VALUES (@AirplaneTypeCommercialAirplaneId, 'CommercialAirplanes')
            INSERT INTO [dbo].[AirplaneTypes] ([Id], [Name]) VALUES (@AirplaneTypePrivateJetId, 'PrivateJets')
            INSERT INTO [dbo].[AirplaneTypes] ([Id], [Name]) VALUES (@AirplaneTypePrivatePropellorPlaneId, 'PrivatePropellorPlanes')
        END


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AirplaneSubTypes')
    IF (SELECT COUNT([dbo].[AirplaneSubTypes].[Name]) FROM [dbo].[AirplaneSubTypes]) = 0
        BEGIN
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Jumbo Passenger Jets', @AirplaneTypeCommercialAirplaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('MidSize Passenger Jets', @AirplaneTypeCommercialAirplaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Light Passenger Jets', @AirplaneTypeCommercialAirplaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Passenger Turbo Props', @AirplaneTypeCommercialAirplaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Cargo Airplanes', @AirplaneTypeCommercialAirplaneId)

            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('VLJ', @AirplaneTypePrivateJetId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Light Business Jets', @AirplaneTypePrivateJetId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Midsize Business Jets', @AirplaneTypePrivateJetId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Heavy Business Jets', @AirplaneTypePrivateJetId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Military Jets', @AirplaneTypePrivateJetId)

            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Private Single Engine', @AirplaneTypePrivatePropellorPlaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Twin Turboprops', @AirplaneTypePrivatePropellorPlaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Aerobatic', @AirplaneTypePrivatePropellorPlaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Amphibious', @AirplaneTypePrivatePropellorPlaneId)
            INSERT INTO [dbo].[AirplaneSubTypes] ([Name], [AirplaneTypeId]) VALUES ('Military Turboprops', @AirplaneTypePrivatePropellorPlaneId)
        END


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ClassTypes')
    IF (SELECT COUNT([dbo].[ClassTypes].[Name]) FROM [dbo].[ClassTypes]) = 0
        BEGIN
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('First Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Business Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Economy Class')
            INSERT INTO [dbo].[ClassTypes] ([Name]) VALUES ('Other')
        END
