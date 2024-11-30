INSERT INTO [User] (Number, [Name]) VALUES ('00','Mallolo Vejar')

INSERT INTO [User] (Number, [Name]) VALUES ('##','CESAT')

---INSERT DATA IN FILES
SET IDENTITY_INSERT [dbo].[Files] ON 
INSERT [dbo].[Files] ([ID], [Name], [Date]) VALUES
(1, N'ColorWire 3 Poles High Speed', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(2, N'ColorWire 4 Poles High Speed', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(3, N'ColorWire 5 Poles High Speed', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(4, N'ColorWire 3 Poles Side A', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(5, N'ColorWire 3 Poles Side B', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(6, N'ColorWire 4 Poles Side A', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(7, N'ColorWire 4 Poles Side B', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(8, N'ColorWire 5 Poles Side A', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(9, N'ColorWire 5 Poles Side B', CAST(N'2024-09-26T12:36:44.997' AS DateTime)),
(10, N'ColorWire 3 Poles Male-Male', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(11, N'ColorWire 3 Poles Female-Female', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(12, N'ColorWire 3 Poles Female Side A', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(13, N'ColorWire 3 Poles Male Side B', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(14, N'ColorWire 4 Poles Male-Male', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(15, N'ColorWire 4 Poles Female-Female', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(16, N'ColorWire 4 Poles Female Side A', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(17, N'ColorWire 4 Poles Male Side B', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(18, N'ColorWire 5 Poles Female-Female', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(19, N'ColorWire 5 Poles Male-Male', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(20, N'ColorWire 5 Poles Female Side A', CAST(N'2024-10-16T11:50:00.000' AS DateTime)),
(21, N'ColorWire 5 Poles Male Side B', CAST(N'2024-10-16T11:50:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Files] OFF

SET IDENTITY_INSERT [dbo].[Tests] ON
INSERT [dbo].[Tests] ([ID],[File],[TestOption],[Wire]) VALUES
(1,1,N'ThreeColor',	1),
(2,1,N'ThreeColor',	3),
(3,1,N'ThreeColor',	2),
(4,1,N'ThreeColor',	6),
(5,1,N'ThreeColor',	7),
(6,1,N'ThreeColor',	8),
(7,3,N'FiveColor',	1),
(8,3,N'FiveColor',	4),
(9,3,N'FiveColor',	2),
(10,3,N'FiveColor',	3),
(11,3,N'FiveColor',	5),
(12,3,N'FiveColor',	6),
(13,3,N'FiveColor',	9),
(14,3,N'FiveColor',	7),
(15,3,N'FiveColor',	8),
(16,3,N'FiveColor',	10),
(17,2,N'FourColor',	1),
(18,2,N'FourColor',	4),
(19,2,N'FourColor',	3),
(20,2,N'FourColor',	2),
(21,2,N'FourColor',	6),
(22,2,N'FourColor',	9),
(23,2,N'FourColor',	7),
(24,2,N'FourColor',	8),
(25,4,N'ThreeColor',1),
(26,4,N'ThreeColor',3),
(27,4,N'ThreeColor',2),
(28,5,N'ThreeColor',6),
(29,5,N'ThreeColor',7),
(30,5,N'ThreeColor',8),
(31,8,N'FiveColor',	1),
(32,8,N'FiveColor',	4),
(33,8,N'FiveColor',	2),
(34,8,N'FiveColor',	3),
(35,8,N'FiveColor',	5),
(36,9,N'FiveColor',	6),
(37,9,N'FiveColor',	9),
(38,9,N'FiveColor',	7),
(39,9,N'FiveColor',	8),
(40,9,N'FiveColor',	10),
(41,6,N'FourColor',	1),
(42,6,N'FourColor',	4),
(43,6,N'FourColor',	2),
(44,6,N'FourColor',	3),
(45,7,N'FourColor',	6),
(46,7,N'FourColor',	9),
(47,7,N'FourColor',	7),
(48,7,N'FourColor',	8),
(49,10,N'ThreeColor',1),
(50,10,N'ThreeColor',3),
(51,10,N'ThreeColor',2),
(52,10,N'ThreeColor',11),
(53,10,N'ThreeColor',13),
(54,10,N'ThreeColor',14),
(55,11,N'ThreeColor',6),
(56,11,N'ThreeColor',8),
(57,11,N'ThreeColor',7),
(58,11,N'ThreeColor',16),
(59,11,N'ThreeColor',18),
(60,11,N'ThreeColor',19),
(61,12,N'ThreeColor',16),
(62,12,N'ThreeColor',18),
(63,12,N'ThreeColor',19),
(64,13,N'ThreeColor',11),
(65,13,N'ThreeColor',13),
(66,13,N'ThreeColor',14),
(67,14,N'FourColor',1),
(68,14,N'FourColor',4),
(69,14,N'FourColor',3),
(70,14,N'FourColor',2),
(71,14,N'FourColor',11),
(72,14,N'FourColor',12),
(73,14,N'FourColor',13),
(74,14,N'FourColor',14),
(75,15,N'FourColor',6),
(76,15,N'FourColor',9),
(77,15,N'FourColor',8),
(78,15,N'FourColor',7),
(79,15,N'FourColor',16),
(80,15,N'FourColor',17),
(81,15,N'FourColor',18),
(82,15,N'FourColor',19),
(83,16,N'FourColor',16),
(84,16,N'FourColor',17),
(85,16,N'FourColor',18),
(86,16,N'FourColor',19),
(87,17,N'FourColor',11),
(88,17,N'FourColor',12),
(89,17,N'FourColor',13),
(90,17,N'FourColor',14),
(91,19,N'FiveColor',1),
(92,19,N'FiveColor',4),
(93,19,N'FiveColor',3),
(94,19,N'FiveColor',2),
(95,19,N'FiveColor',5),
(96,19,N'FiveColor',11),
(97,19,N'FiveColor',12),
(98,19,N'FiveColor',13),
(99,19,N'FiveColor',14),
(100,19,N'FiveColor',15),
(101,18,N'FiveColor',6),
(102,18,N'FiveColor',9),
(103,18,N'FiveColor',8),
(104,18,N'FiveColor',7),
(105,18,N'FiveColor',10),
(106,18,N'FiveColor',16),
(107,18,N'FiveColor',17),
(108,18,N'FiveColor',18),
(109,18,N'FiveColor',19),
(110,18,N'FiveColor',20),
(111,20,N'FiveColor',16),
(112,20,N'FiveColor',17),
(113,20,N'FiveColor',18),
(114,20,N'FiveColor',19),
(115,20,N'FiveColor',20),
(116,21,N'FiveColor',11),
(117,21,N'FiveColor',12),
(118,21,N'FiveColor',13),
(119,21,N'FiveColor',14),
(120,21,N'FiveColor',15),
(121,21,N'FiveColor',16)
SET IDENTITY_INSERT [dbo].[Tests] OFF

---INSERT DATA IN WIRE
SET IDENTITY_INSERT [dbo].[Wire] ON
INSERT [dbo].[Wire]([ID],[WireColor],[Program],[PosCam],[PosWire]) VALUES
(1,'Brown',	0,	13973,	973),
(2,'Black',	0,	13973,	3583),
(3,'Blue',	0,	13973,	-4074),
(4,'White',	0,	13973,	-1458),
(5,'Green',	0,	13973,	2514),
(6,'Brown',	1,	-15621,	-2043),
(7,'Black',	1,	-15621,	-4285),
(8,'Blue',	1,	-15621,	3390),
(9,'White',	1,	-15621,	856),
(10,'Green',1,	-15621,	-3082),
(11,'Brown',	2,	-15621,	694),
(12,'White',	2,	-15621,	-1965),
(13,'Blue',		2,	-15621,	4296),
(14,'Black',	2,	-15621,	3228),
(15,'Green',	2,	-15621,	1526),
(16,'Brown',	3,	13973,-1448),
(17,'White',	3,	13973,	897),
(18,'Blue',		3,	13973,	3472),
(19,'Black',	3,	13973,	-4053),
(20,'Green',	3,	13973,	-2817)
SET IDENTITY_INSERT [dbo].[Wire] OFF

---INSERT DATA IN CONNECTOR CONFIGS
SET IDENTITY_INSERT [dbo].[ConnectorConfigs] ON
INSERT [dbo].[ConnectorConfigs] ([ID], [File], [Side], [ConnectorType], [Poles]) VALUES
(1, 1, N'A', N'Male', N'1,3,4'),
(2, 1, N'B', N'Female', N'1,3,4'),
(3, 2, N'A', N'Male', N'1,2,3,4'),
(4, 2, N'B', N'Female', N'1,2,3,4'),
(5, 3, N'A', N'Male', N'1,2,3,4,5'),
(6, 3, N'B', N'Female', N'1,2,3,4,5'),
(7, 4, N'A', N'Male', N'1,3,4'),
(8, 5, N'B', N'Female', N'1,3,4'),
(9, 6, N'A', N'Male', N'1,2,3,4'),
(10,7, N'B', N'Female', N'1,2,3,4'),
(11,8, N'A', N'Male', N'1,2,3,4,5'),
(12,9, N'B', N'Female', N'1,2,3,4,5'),
(13, 10, N'A', N'Male',		N'1,3,4'),
(14, 10, N'B', N'Male',		N'1,3,4'),
(15, 11, N'A', N'Female',	N'1,3,4'),
(16, 11, N'B', N'Female',	N'1,3,4'),
(17, 12, N'A', N'Female',	N'1,3,4'),
(18, 13, N'B', N'Male',		N'1,3,4'),
(19, 14, N'A', N'Male',		N'1,2,3,4'),
(20, 14, N'B', N'Male',		N'1,2,3,4'),
(21, 15, N'A', N'Female',	N'1,2,3,4'),
(22, 15, N'A', N'Female',	N'1,2,3,4'),
(23, 16, N'A', N'Female',	N'1,2,3,4'),
(24, 17, N'B', N'Male',		N'1,2,3,4'),
(25, 18, N'A', N'Female',	N'1,2,3,4,5'),
(26, 18, N'B', N'Female',	N'1,2,3,4,5'),
(27, 19, N'A', N'Male',		N'1,2,3,4,5'),
(28, 19, N'B', N'Male',		N'1,2,3,4,5'),
(29, 20, N'A', N'Female',	N'1,2,3,4,5'),
(30, 21, N'B', N'Male',		N'1,2,3,4,5')
SET IDENTITY_INSERT [dbo].[ConnectorConfigs] OFF


---SELECT INFORMATION WITH FILE
USE [BeldenValitacion] SELECT cc.* FROM [Files] f LEFT JOIN ConnectorConfigs cc ON cc.[File] = f.ID WHERE f.ID = 21
USE [BeldenValitacion] SELECT f.ID, t.ID TestID,w.ID WireID, f.*, t.*,w.*
FROM [dbo].[Files] f 
LEFT JOIN [dbo].[Tests] t ON f.[ID] = t.[File]  
LEFT JOIN [dbo].[Wire] w ON t.[Wire] = w.[ID]
WHERE f.[ID] BETWEEN 18 AND 22

USE BeldenValitacion select ID as No, Name, Date from Files

----SELECT RESULT WITH FILE
USE [BeldenValitacion] SELECT rw.ID as No, rw.[WireLabelID] as ID_Wire,rw.[WireColor] as Color, rw.[Status]
FROM [dbo].[Results] r
LEFT JOIN [dbo].[ResultWireColor] rw ON r.[WireLabel] = rw.[WireLabelID]
WHERE r.[ID] = 5

USE [BeldenValitacion] SELECT f.ID FileID,r.ID ResultID, f.[Name],r.[ID],r.[UserNumber],r.[UserName],r.[WireLabel] FROM [dbo].[Files] f
LEFT JOIN [dbo].[Results] r ON r.[FileName] = f.[Name] WHERE f.[ID] = 5

---SELECT ALL INFORMATION TO TABLES
SELECT * FROM [User]
SELECT * FROM [ConnectorConfigs]
SELECT * FROM [Files] WHERE [ID]  BETWEEN 18 AND 22

SELECT * FROM [Wire]
SELECT * FROM [Tests]
SELECT * FROM [Results]
SELECT * FROM [ResultWireColor]


------DELETE INFORMATION TO TABLES WITH FILE
USE BeldenValitacion DELETE w FROM [Wire] w LEFT JOIN [Tests] t ON t.[Wire] = w.[ID] WHERE t.[ID] = 1;
USE BeldenValitacion DELETE w
FROM [Wire] w
WHERE w.[ID] NOT IN (
  SELECT t.[ID]
  FROM [Tests] t
  WHERE t.[ID] = 7
);


/*---------------------------------------------DELETE DATA --------------------------------------------------------------

---------------------------------------------DELETE DATA IN SQL--------------------------------------------------------------

DELETE FROM [Wire] WHERE [ID] BETWEEN 4 AND 10
DELETE FROM [Tests] WHERE [ID] BETWEEN 1 AND 9 
DELETE FROM [Files] WHERE [ID] = 5
---------------------------------------------DELETE DATA IN C#---------------------------------------------------------------

USE [BeldenValitacion] DELETE cc FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
ON t.[Wire] = w.[ID] 
WHERE f.[ID] = 7
USE [BeldenValitacion] DELETE w FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
ON t.[Wire] = w.[ID] 
WHERE f.[ID] = 7 
USE [BeldenValitacion] DELETE t FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
ON t.[Wire] = w.[ID]
WHERE f.[ID] = 7
USE [BeldenValitacion] DELETE f FROM [Files] f LEFT JOIN [Tests] t ON t.[File] = f.[ID] LEFT JOIN [ConnectorConfigs] cc
ON cc.[File] = f.[ID]  LEFT JOIN [Wire] w
ON t.[Wire] = w.[ID] 
WHERE f.[ID] = 7

---------------------------------------------DROP TABLE IN SQL---------------------------------------------------------------
DROP TABLE [User]
DROP TABLE [Wire]	
DROP TABLE [ConnectorConfigs]
DROP TABLE [Results]
DROP TABLE [ResultWireColor]
*/


