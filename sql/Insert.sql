CREATE TABLE [User] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Number] nvarchar(255) NOT NULL,
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [UserHistory] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [User] int NOT NULL,
  [Action] nvarchar(255) NOT NULL,
  [Date] datetime NOT NULL
)
GO

CREATE TABLE [Files] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Date] datetime NOT NULL
)
GO
 


CREATE TABLE [Tests] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [File] int NOT NULL,
  [TestOption] nvarchar(255) NOT NULL,
  [Wire] int NOT NULL
)
GO

CREATE TABLE [Wire]
(
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [WireColor] nvarchar(255) NOT NULL,
  [Program] int NOT NULL,
  [PosCam] int NOT NULL,
  [PosWire] int NOT NULL
)

CREATE TABLE [ConnectorConfigs] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [File] int NOT NULL,
  [Side] nvarchar(255) NOT NULL,
  [ConnectorType] nvarchar(255) NOT NULL,
  [Poles] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Results] (
  [ID] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [UserNumber] nvarchar(255) NOT NULL,
  [UserName] nvarchar(255) NOT NULL,
  [FileName] nvarchar(255) NOT NULL,
  [WireLabel] nvarchar(255) NOT NULL	
)
GO
CREATE TABLE [ResultWireColor]
(
[ID] int PRIMARY KEY NOT NULL IDENTITY(1,1),
[WireLabelID] nvarchar(255) NOT NULL,
[Wire] int NOT NULL, 
[WireColor] nvarchar(255) NOT NULL,
[Status] nvarchar(255) NOT NULL
)
GO
