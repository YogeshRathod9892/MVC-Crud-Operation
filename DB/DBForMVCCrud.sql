Create database NIMAP 
USE [NIMAP]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 24-01-2021 03:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_name] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 24-01-2021 03:44:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Id] [int] NULL,
	[Product_Name] [varchar](100) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Category_Id], [Category_name]) VALUES (1, N'car')
GO
INSERT [dbo].[Category] ([Category_Id], [Category_name]) VALUES (3, N'Bike')
GO
INSERT [dbo].[Category] ([Category_Id], [Category_name]) VALUES (4, N'Truck')
GO
INSERT [dbo].[Category] ([Category_Id], [Category_name]) VALUES (8, N'VIP')
GO
INSERT [dbo].[Category] ([Category_Id], [Category_name]) VALUES (7, N'XUV')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (5, 3, N'yogesh')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (3, 1, N'Mirror')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (4, 4, N'Seat')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (6, 1, N'whil')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (7, 4, N'sound')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (8, 1, N'glass')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (9, 4, N'window')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (10, 7, N'wipe')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (11, 1, N'Gard')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (12, 1, N'Policy')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (13, 7, N'Ac kit')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (14, 3, N'Insurance')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (15, 4, N'Bajaj Insurance')
GO
INSERT [dbo].[Product] ([Product_Id], [Category_Id], [Product_Name]) VALUES (16, 8, N'Spray form')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
