CREATE DATABASE [sigil]
GO
USE [sigil]
GO
/****** Object:  Table [dbo].[players]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players_units]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players_units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[players_id] [int] NULL,
	[units_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[units]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[unit_name] [varchar](50) NULL,
	[unit_type] [varchar](50) NULL,
	[weapon_id] [int] NULL,
	[hp] [int] NULL,
	[str] [int] NULL,
	[skl] [int] NULL,
	[spd] [int] NULL,
	[lck] [int] NULL,
	[def] [int] NULL,
	[res] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[weapons]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[weapons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wep_name] [varchar](50) NULL,
	[wep_type] [varchar](50) NULL,
	[rng] [int] NULL,
	[dmg] [int] NULL,
	[hit] [int] NULL,
	[crt] [int] NULL,
	[tri_strong] [varchar](50) NULL,
	[tri_weak] [varchar](50) NULL,
	[effect] [varchar](50) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[units] ON 

INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (1, N'Florina', N'Falcoknight', 10, 20, 6, 7, 7, 2, 5, 4)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (2, N'Hawkeye', N'Berserker', 3, 24, 7, 6, 7, 2, 6, 0)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (3, N'Geitz', N'Warrior', 3, 28, 8, 5, 6, 2, 5, 0)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (4, N'Canas', N'Druid', 9, 19, 6, 3, 4, 2, 4, 6)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (5, N'Renault', N'Bishop', 8, 21, 4, 4, 4, 2, 3, 8)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (6, N'Erk', N'Sage', 7, 20, 5, 4, 4, 2, 5, 5)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (7, N'Heath', N'Wyvern Lord', 2, 25, 9, 5, 7, 2, 10, 1)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (8, N'Rath', N'Nomad Trooper', 1, 21, 7, 6, 7, 2, 6, 3)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (9, N'Wil', N'Sniper', 6, 21, 7, 6, 5, 2, 5, 2)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (10, N'Jaffar', N'Assassin', 5, 16, 3, 1, 9, 2, 2, 0)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (11, N'Guy', N'Swordmaster', 4, 21, 6, 11, 10, 2, 5, 2)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (12, N'Raven', N'Hero', 1, 22, 6, 9, 10, 2, 8, 2)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (13, N'Wallace', N'General', 2, 21, 8, 4, 3, 2, 13, 3)
INSERT [dbo].[units] ([id], [unit_name], [unit_type], [weapon_id], [hp], [str], [skl], [spd], [lck], [def], [res]) VALUES (14, N'Sain', N'Paladin', 1, 23, 7, 4, 7, 2, 8, 3)
SET IDENTITY_INSERT [dbo].[units] OFF
SET IDENTITY_INSERT [dbo].[weapons] ON 

INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (1, N'Steel Sword', N'sword', 1, 8, 70, 0, N'axe', N'lance', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (2, N'Steel Lance', N'lance', 1, 10, 70, 0, N'sword', N'axe', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (3, N'Steel Axe', N'axe', 1, 11, 65, 0, N'lance', N'sword', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (4, N'Wo Dao', N'sword', 1, 8, 75, 35, N'axe', N'lance', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (5, N'Killing Edge', N'sword', 1, 9, 75, 30, N'axe', N'lance', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (6, N'Steel Bow', N'bow', 2, 9, 70, 0, null, null, N'flying')
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (7, N'Elfire', N'anima', 2, 10, 85, 0, N'light', N'dark', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (8, N'Divine', N'light', 2, 8, 85, 10, N'dark', N'anima', null)
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (9, N'Nosferatu', N'dark', 2, 10, 70, 0, N'anima', N'light', N'heals for damage done')
INSERT [dbo].[weapons] ([id], [wep_name], [wep_type], [rng], [dmg], [hit], [crt], [tri_strong], [tri_weak], [effect]) VALUES (10, N'Short Spear', N'lance', 2, 9, 60, 0, N'sword', N'axe', null)
SET IDENTITY_INSERT [dbo].[weapons] OFF

CREATE DATABASE [sigil_test]
GO
USE [sigil_test]
GO
/****** Object:  Table [dbo].[players]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[players_units]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players_units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[players_id] [int] NULL,
	[units_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[units]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[unit_name] [varchar](50) NULL,
	[unit_type] [varchar](50) NULL,
	[weapon_id] [int] NULL,
	[hp] [int] NULL,
	[str] [int] NULL,
	[skl] [int] NULL,
	[spd] [int] NULL,
	[lck] [int] NULL,
	[def] [int] NULL,
	[res] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[weapons]    Script Date: 3/7/2017 4:39:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[weapons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wep_name] [varchar](50) NULL,
	[wep_type] [varchar](50) NULL,
	[rng] [int] NULL,
	[dmg] [int] NULL,
	[hit] [int] NULL,
	[crt] [int] NULL,
	[tri_strong] [varchar](50) NULL,
	[tri_weak] [varchar](50) NULL,
	[effect] [varchar](50) NULL
) ON [PRIMARY]

GO