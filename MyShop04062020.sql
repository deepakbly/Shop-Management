USE [master]
GO
/****** Object:  Database [MyShop]    Script Date: 06/04/2020 17:15:10 ******/
CREATE DATABASE [MyShop] ON  PRIMARY 
( NAME = N'MyShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MyShop.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MyShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyShop] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyShop] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MyShop] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MyShop] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MyShop] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MyShop] SET ARITHABORT OFF
GO
ALTER DATABASE [MyShop] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MyShop] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MyShop] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MyShop] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MyShop] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MyShop] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MyShop] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MyShop] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MyShop] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MyShop] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MyShop] SET  DISABLE_BROKER
GO
ALTER DATABASE [MyShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MyShop] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MyShop] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MyShop] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MyShop] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MyShop] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MyShop] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MyShop] SET  READ_WRITE
GO
ALTER DATABASE [MyShop] SET RECOVERY FULL
GO
ALTER DATABASE [MyShop] SET  MULTI_USER
GO
ALTER DATABASE [MyShop] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MyShop] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyShop', N'ON'
GO
USE [MyShop]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 06/04/2020 17:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[c_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[customer_address] [varchar](200) NULL,
	[customer_contactno] [varchar](10) NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCustomer] ON
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (2, 2, N'Abhishek', N'akhlas', N'462394243')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (81, 2, N'AnujSir', N'sdfsd', N'6934233')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (82, 2, N'Rakesh', N'gfdhg', N'4525')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (83, 2, N'Rakesh', N'gfdhg', N'4525')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (84, 2, N'ggggggg', N'fdfdf', N'143143')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (92, 0, N'Loooka', N'abbbc', N'123137')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (93, 0, N'rajmalhotra', N'khskdla', N'36423')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (94, 0, N'RamKishore', N'jhdskjf', N'647324')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (95, 0, N'hhhhh', N'hhhhh', N'666366')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (96, 0, N'hhhhh', N'hhhhh', N'666366')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (97, 0, N'Ajayvdas', N'khsdla', N'263412')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (98, 0, N'Ajayvdas', N'khsdla', N'263412')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (99, 0, N'lllllllll', N'llllllll', N'9999999')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (100, 0, N'hhhhhh', N'hhhhh', N'7777777')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (101, 0, N'hhhhhh', N'hhhhh', N'7777777')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (102, 0, N'RRRRRR', N'ghasgd', N'873121')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (103, 0, N'RRRRRR', N'ghasgd', N'873121')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (104, 0, N'Anju', N'jskjd', N'236213')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (105, 0, N'radhika', N'sg', N'8312')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (106, 0, N'Appppp', N'sdah', N'7343')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (107, 0, N'Abhiram', N'gasdj', N'67333')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (108, 0, N'Bp', N'jdasj', N'834234')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (109, 0, N'NNN', N'jsdjk', N'34823')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (110, 0, N'jhczkjx', N'dsalid', N'36423')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (111, 2, N'Agnihotri', N'jsd', N'649')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (112, 2, N'Abhijit', N'jsg', N'2531')
INSERT [dbo].[tblCustomer] ([id], [c_id], [customer_name], [customer_address], [customer_contactno]) VALUES (113, 2, N'Pinki', N'jhsd', N'86391')
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
/****** Object:  Table [dbo].[tblCustMgmt]    Script Date: 06/04/2020 17:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustMgmt](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NULL,
	[type] [varchar](100) NULL,
	[discription] [varchar](500) NULL,
	[amount] [decimal](18, 2) NULL,
	[date] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCustMgmt] ON
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (1, 2, N'Apne Diye', N'dshflsdf', CAST(100.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (14, 109, N'Apko Mile', N'jasd', CAST(324423.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (15, 110, N'Apko Mile', N'dfsk', CAST(3631.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (16, 111, N'Apko Mile', N'hd', CAST(100.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (17, 111, N'Apne Diye', N'sadad', CAST(80.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (18, 111, N'Apne Diye', N'dfda', CAST(200.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (19, 112, N'Apne Diye', N'kas', CAST(299.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (11, 65, N'Apko Mile', N'fjsdf', CAST(2000.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (12, 107, N'Apne Diye', N'available', CAST(5550.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (13, 108, N'Apko Mile', N'dsidas', CAST(200.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
INSERT [dbo].[tblCustMgmt] ([id], [customer_id], [type], [discription], [amount], [date]) VALUES (20, 113, N'Apne Diye', N'khsda', CAST(3000.00 AS Decimal(18, 2)), CAST(0xD1400B00 AS Date))
SET IDENTITY_INSERT [dbo].[tblCustMgmt] OFF
/****** Object:  Table [dbo].[tblCompany]    Script Date: 06/04/2020 17:15:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCompany](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [varchar](200) NULL,
	[c_ownername] [varchar](50) NULL,
	[c_address] [varchar](500) NULL,
	[c_contactno] [varchar](10) NULL,
	[owner_no] [varchar](10) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](10) NULL,
 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCompany] ON
INSERT [dbo].[tblCompany] ([id], [c_name], [c_ownername], [c_address], [c_contactno], [owner_no], [username], [password]) VALUES (1, N'dhfsd', N'dhfsdf', N'', N'', N'3424823', N'abc', N'111')
INSERT [dbo].[tblCompany] ([id], [c_name], [c_ownername], [c_address], [c_contactno], [owner_no], [username], [password]) VALUES (2, N'Friends Hub', N'Ankit', N'Bareilly', N'98989898', N'12331', N'deep', N'121')
SET IDENTITY_INSERT [dbo].[tblCompany] OFF
/****** Object:  StoredProcedure [dbo].[TransacIn]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TransacIn] (@customer_id int
           ,@type varchar(100)
           ,@discription varchar(500)
           ,@amount decimal(18,2)
           ,@date datetime)
           
as

INSERT INTO [MyShop].[dbo].[tblCustMgmt]
           ([customer_id]
           ,[type]
           ,[discription]
           ,[amount]
           ,[date])
     VALUES
           (@customer_id
           ,@type
           ,@discription
           ,@amount
           ,@date)
GO
/****** Object:  StoredProcedure [dbo].[ProfileUpdation]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ProfileUpdation](@id int
			,@c_name varchar(200)
		    ,@c_ownername varchar(50)
			,@c_address varchar(500)
			,@c_contactno varchar(10)
		    ,@owner_no varchar(10))
as
UPDATE [MyShop].[dbo].[tblCompany]
   SET [c_name] = @c_name
      ,[c_ownername] = @c_ownername
      ,[c_address] = @c_address
      ,[c_contactno] = @c_contactno
      ,[owner_no] = @owner_no
 WHERE @id=id
GO
/****** Object:  StoredProcedure [dbo].[CustomerUp]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CustomerUp](@id int
           ,@customer_name varchar(50)
           ,@customer_address varchar(200)
           ,@customer_contactno varchar(10))
as
UPDATE [MyShop].[dbo].[tblCustomer]
   SET [customer_name] = @customer_name
      ,[customer_address] = @customer_address
      ,[customer_contactno] = @customer_contactno
 WHERE @id=id
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CustomerInsert] (@c_id int
           ,@customer_name varchar(50)
           ,@customer_address varchar(200)
           ,@customer_contactno varchar(10))
as
INSERT INTO [MyShop].[dbo].[tblCustomer]
           ([c_id]
           ,[customer_name]
           ,[customer_address]
           ,[customer_contactno])
     VALUES
           (@c_id
           ,@customer_name
           ,@customer_address
           ,@customer_contactno)
GO
/****** Object:  StoredProcedure [dbo].[CustomerIn]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CustomerIn](@c_name varchar(200)
           ,@c_ownername varchar(50)
           ,@c_address varchar(500)
           ,@c_contactno varchar(10)
           ,@owner_no varchar(10)
           ,@username varchar(50)
           ,@password varchar(10))
as

INSERT INTO [MyShop].[dbo].[tblCompany]
           ([c_name]
           ,[c_ownername]
           ,[c_address]
           ,[c_contactno]
           ,[owner_no]
           ,[username]
           ,[password])
     VALUES
           (@c_name
           ,@c_ownername
           ,@c_address
           ,@c_contactno
           ,@owner_no
           ,@username
           ,@password)
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 06/04/2020 17:15:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangePassword](@id int
		,@password varchar(10))
as

UPDATE [MyShop].[dbo].[tblCompany]
   SET [password] = @password
 WHERE @id=id
GO
