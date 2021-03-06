USE [master]
GO
/****** Object:  Database [Customer]    Script Date: 14/03/2020 10:36:05 ******/
CREATE DATABASE [Customer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Customer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DESENV\MSSQL\DATA\Customer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Customer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DESENV\MSSQL\DATA\Customer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Customer] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Customer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Customer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Customer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Customer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Customer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Customer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Customer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Customer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Customer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Customer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Customer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Customer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Customer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Customer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Customer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Customer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Customer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Customer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Customer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Customer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Customer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Customer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Customer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Customer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Customer] SET  MULTI_USER 
GO
ALTER DATABASE [Customer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Customer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Customer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Customer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Customer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Customer] SET QUERY_STORE = OFF
GO
USE [Customer]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/03/2020 10:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 14/03/2020 10:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CEP] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14/03/2020 10:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[IdCategory] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 14/03/2020 10:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressId] [int] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 14/03/2020 10:36:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](250) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedAt] [datetime] NULL,
	[IdCategory] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190320191123_Initial', N'3.1.0')
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [CEP]) VALUES (1, N'72870221')
INSERT [dbo].[Address] ([Id], [CEP]) VALUES (2, N'72870263')
INSERT [dbo].[Address] ([Id], [CEP]) VALUES (3, N'50080490')
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (1, N'Canecas', N'Canecas', NULL, CAST(N'2020-03-11T23:02:27.893' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (2, N'Roupas', N'Roupas', NULL, CAST(N'2020-03-11T23:02:38.170' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (3, N'Miniaturas', N'Miniaturas', NULL, CAST(N'2020-03-11T23:02:51.230' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (4, N'Bonés', N'Bonés', NULL, CAST(N'2020-03-11T23:03:00.300' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (5, N'Casa', N'Casa', NULL, CAST(N'2020-03-11T23:03:11.010' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (6, N'Cerâmica', N'Canecas de Cerâmica', 1, CAST(N'2020-03-11T23:03:42.473' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (7, N'Masculina', N'Camisas Masculina', 2, CAST(N'2020-03-11T23:04:21.890' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (8, N'Feminina', N'Camisas Femininas', 2, CAST(N'2020-03-11T23:04:44.760' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (9, N'Infantil', N'Camisas Infantis', 2, CAST(N'2020-03-11T23:05:01.530' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (10, N'Action Figure', N'Action Figure', 3, CAST(N'2020-03-11T23:05:18.917' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Description], [IdCategory], [CreatedAt], [ModifiedAt]) VALUES (11, N'Bobble Head', N'Bobble Head', 3, CAST(N'2020-03-11T23:06:12.610' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [AddressId], [Name], [DateCreated]) VALUES (2, 2, N'Jose', CAST(N'2019-12-30T23:21:19.8166667' AS DateTime2))
INSERT [dbo].[Customer] ([Id], [AddressId], [Name], [DateCreated]) VALUES (3, 3, N'Maria', CAST(N'2019-12-30T23:21:19.8166667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [CreatedAt], [ModifiedAt], [IdCategory]) VALUES (1, N'Caneca Rock In Roll', N'Caneca de cerâmica branca', CAST(N'2020-03-11T22:45:20.080' AS DateTime), NULL, 6)
INSERT [dbo].[Product] ([Id], [Name], [Description], [CreatedAt], [ModifiedAt], [IdCategory]) VALUES (2, N'Camisa AC/DC', N'Camisa de algodão preta', CAST(N'2020-03-11T22:45:20.080' AS DateTime), NULL, 7)
INSERT [dbo].[Product] ([Id], [Name], [Description], [CreatedAt], [ModifiedAt], [IdCategory]) VALUES (3, N'Caneca The Doors', N'Caneca de cerâmica branca', CAST(N'2020-03-13T20:26:28.873' AS DateTime), NULL, 6)
INSERT [dbo].[Product] ([Id], [Name], [Description], [CreatedAt], [ModifiedAt], [IdCategory]) VALUES (4, N'Caneca Ramones', N'Caneca de cerâmica branca ', CAST(N'2020-03-13T20:26:42.347' AS DateTime), NULL, 6)
INSERT [dbo].[Product] ([Id], [Name], [Description], [CreatedAt], [ModifiedAt], [IdCategory]) VALUES (5, N'Caneca The Beatles', N'Caneca de cerâmica branca', CAST(N'2020-03-13T20:27:01.277' AS DateTime), NULL, 6)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Index [IX_Customer_AddressId]    Script Date: 14/03/2020 10:36:05 ******/
CREATE NONCLUSTERED INDEX [IX_Customer_AddressId] ON [dbo].[Customer]
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Address_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Address_AddressId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [Customer] SET  READ_WRITE 
GO
