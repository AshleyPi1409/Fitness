USE [master]
GO
/****** Object:  Database [FitnessManager]    Script Date: 6/3/2016 3:20:27 PM ******/
CREATE DATABASE [FitnessManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FitnessManager', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FitnessManager.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FitnessManager_log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FitnessManager_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FitnessManager] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FitnessManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FitnessManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FitnessManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FitnessManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FitnessManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FitnessManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [FitnessManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FitnessManager] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FitnessManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FitnessManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FitnessManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FitnessManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FitnessManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FitnessManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FitnessManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FitnessManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FitnessManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FitnessManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FitnessManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FitnessManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FitnessManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FitnessManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FitnessManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FitnessManager] SET  MULTI_USER 
GO
ALTER DATABASE [FitnessManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FitnessManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FitnessManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FitnessManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FitnessManager]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[accountName] [nvarchar](50) NULL,
	[password] [varchar](50) NULL,
	[fullName] [nvarchar](max) NULL,
	[roleID] [int] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[staff] [int] NULL,
	[booked] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booked]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booked](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[customer] [int] NULL,
	[staff] [int] NULL,
	[course] [int] NULL,
	[startDay] [datetime] NULL,
	[paid] [bit] NULL,
 CONSTRAINT [PK_Booked] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Months] [decimal](18, 1) NULL,
	[Price] [decimal](18, 2) NULL,
	[IDType] [int] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Diary]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[account] [int] NULL,
	[date] [datetime] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Diary] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Functions]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[functionName] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role_Func]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_Func](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDRole] [int] NULL,
	[IDFunc] [int] NULL,
 CONSTRAINT [PK_Role_Func] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Type]    Script Date: 6/3/2016 3:20:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [accountName], [password], [fullName], [roleID], [active]) VALUES (1, N'admin', N'admin', N'administraror', 1, 1)
INSERT [dbo].[Accounts] ([ID], [accountName], [password], [fullName], [roleID], [active]) VALUES (2, N'baoan', N'baoan', N'staff', 2, 0)
INSERT [dbo].[Accounts] ([ID], [accountName], [password], [fullName], [roleID], [active]) VALUES (4, N'vinhthai', N'vinhthai', N'Vinh Thái', 1, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [staff], [booked], [date]) VALUES (1, 1, 1002, CAST(0x0000A61A00F5282F AS DateTime))
INSERT [dbo].[Bill] ([ID], [staff], [booked], [date]) VALUES (2, 1, 1003, CAST(0x0000A61A00F5E68F AS DateTime))
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[Booked] ON 

INSERT [dbo].[Booked] ([ID], [customer], [staff], [course], [startDay], [paid]) VALUES (1, 1, 1, 1, CAST(0x0000A61900F68BE4 AS DateTime), 1)
INSERT [dbo].[Booked] ([ID], [customer], [staff], [course], [startDay], [paid]) VALUES (2, 1002, 1, 1002, CAST(0x0000A61900F68BE4 AS DateTime), 1)
INSERT [dbo].[Booked] ([ID], [customer], [staff], [course], [startDay], [paid]) VALUES (3, 1002, 1, 2, CAST(0x0000A61900F68BE4 AS DateTime), 0)
INSERT [dbo].[Booked] ([ID], [customer], [staff], [course], [startDay], [paid]) VALUES (1002, 1, 1, 2, CAST(0x0000A61A00E20E26 AS DateTime), 1)
INSERT [dbo].[Booked] ([ID], [customer], [staff], [course], [startDay], [paid]) VALUES (1003, 2002, 1, 1003, CAST(0x0000A61A00EF41FC AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Booked] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1, N'Summer Course', CAST(3.0 AS Decimal(18, 1)), CAST(12000000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (2, N'Winter Course', CAST(3.5 AS Decimal(18, 1)), CAST(12312312.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1002, N'Autumn', CAST(3.5 AS Decimal(18, 1)), CAST(50000000.00 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1003, N'Spring ', CAST(3.5 AS Decimal(18, 1)), CAST(12312312.00 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1004, N'ABC course', CAST(3.0 AS Decimal(18, 1)), CAST(12000000.00 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1005, N'DMz', CAST(3.0 AS Decimal(18, 1)), CAST(12000000.00 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[Course] ([ID], [Name], [Months], [Price], [IDType], [active]) VALUES (1006, N'PAM', CAST(3.0 AS Decimal(18, 1)), CAST(12000000.00 AS Decimal(18, 2)), 2, 0)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [FullName], [Address], [Phone]) VALUES (1, N'Nguyen Van', N'123 Hà Nội', N'012345689')
INSERT [dbo].[Customer] ([ID], [FullName], [Address], [Phone]) VALUES (1002, N'Duc Minh', N'123 Doi Cung', N'123456489')
INSERT [dbo].[Customer] ([ID], [FullName], [Address], [Phone]) VALUES (2002, N'Hai Nam', N'Bến Nghé', N'99999999')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [roleName], [description], [active]) VALUES (1, N'admin', N'adminstrator', 1)
INSERT [dbo].[Roles] ([ID], [roleName], [description], [active]) VALUES (2, N'staff', N'nhân viên', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([ID], [Name], [description], [active]) VALUES (1, N'Weight Gain', N'Tăng cân', 1)
INSERT [dbo].[Type] ([ID], [Name], [description], [active]) VALUES (2, N'Weight Loss', N'Giảm cân', 1)
SET IDENTITY_INSERT [dbo].[Type] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles] FOREIGN KEY([roleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Accounts] FOREIGN KEY([staff])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Accounts]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Booked] FOREIGN KEY([booked])
REFERENCES [dbo].[Booked] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Booked]
GO
ALTER TABLE [dbo].[Booked]  WITH CHECK ADD  CONSTRAINT [FK_Booked_Accounts] FOREIGN KEY([staff])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Booked] CHECK CONSTRAINT [FK_Booked_Accounts]
GO
ALTER TABLE [dbo].[Booked]  WITH CHECK ADD  CONSTRAINT [FK_Booked_Course] FOREIGN KEY([course])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Booked] CHECK CONSTRAINT [FK_Booked_Course]
GO
ALTER TABLE [dbo].[Booked]  WITH CHECK ADD  CONSTRAINT [FK_Booked_Customer] FOREIGN KEY([customer])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Booked] CHECK CONSTRAINT [FK_Booked_Customer]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Type] FOREIGN KEY([IDType])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Type]
GO
ALTER TABLE [dbo].[Diary]  WITH CHECK ADD  CONSTRAINT [FK_Diary_Accounts] FOREIGN KEY([account])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Diary] CHECK CONSTRAINT [FK_Diary_Accounts]
GO
ALTER TABLE [dbo].[Role_Func]  WITH CHECK ADD  CONSTRAINT [FK_Role_Func_Functions] FOREIGN KEY([IDFunc])
REFERENCES [dbo].[Functions] ([ID])
GO
ALTER TABLE [dbo].[Role_Func] CHECK CONSTRAINT [FK_Role_Func_Functions]
GO
ALTER TABLE [dbo].[Role_Func]  WITH CHECK ADD  CONSTRAINT [FK_Role_Func_Roles] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Role_Func] CHECK CONSTRAINT [FK_Role_Func_Roles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ngay tra tien' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bill', @level2type=N'COLUMN',@level2name=N'date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ngay bat dau hoc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Booked', @level2type=N'COLUMN',@level2name=N'startDay'
GO
USE [master]
GO
ALTER DATABASE [FitnessManager] SET  READ_WRITE 
GO
