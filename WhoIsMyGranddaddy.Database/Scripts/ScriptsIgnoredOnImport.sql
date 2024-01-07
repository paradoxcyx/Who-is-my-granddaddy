
USE [master]
GO

/****** Object:  Database [WhoIsMyGranddaddy]    Script Date: 2024/01/07 02:03:21 ******/
CREATE DATABASE [WhoIsMyGranddaddy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WhoIsMyGranddaddy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WhoIsMyGranddaddy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WhoIsMyGranddaddy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WhoIsMyGranddaddy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET COMPATIBILITY_LEVEL = 160
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WhoIsMyGranddaddy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ANSI_NULLS OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ANSI_PADDING OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ARITHABORT OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET  ENABLE_BROKER
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET READ_COMMITTED_SNAPSHOT ON
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET RECOVERY FULL
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET  MULTI_USER
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET DB_CHAINING OFF
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET DELAYED_DURABILITY = DISABLED
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET ACCELERATED_DATABASE_RECOVERY = OFF
GO

EXEC sys.sp_db_vardecimal_storage_format N'WhoIsMyGranddaddy', N'ON'
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET QUERY_STORE = ON
GO

USE [WhoIsMyGranddaddy]
GO

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/01/07 02:03:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [site].[Persons]    Script Date: 2024/01/07 02:03:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231230135258_InitialCreate', N'6.0.25')
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231230141326_MakeMotherIdAndFatherIdNullable', N'6.0.25')
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231230150214_AddDescendantsByPersonIdSpMigration', N'6.0.25')
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231231081334_AddRootAscendantsByPersonIdSp', N'6.0.25')
GO

SET IDENTITY_INSERT [site].[Persons] ON
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (1, NULL, NULL, N'John', N'Doe', CAST(N'1980-01-01T00:00:00.0000000' AS DateTime2), N'ID1')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (2, NULL, NULL, N'Amy', N'Doe', CAST(N'1970-01-01T00:00:00.0000000' AS DateTime2), N'ID2')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (4, 1, 2, N'Lilly', N'Doe', CAST(N'1970-01-01T00:00:00.0000000' AS DateTime2), N'ID3')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (5, 1, 2, N'Johnny', N'Doe', CAST(N'1960-01-01T00:00:00.0000000' AS DateTime2), N'ID4')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (6, 1, 2, N'Sam', N'Doe', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), N'ID5')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (7, 9, 10, N'Frank', N'Doe', CAST(N'2002-01-01T00:00:00.0000000' AS DateTime2), N'ID6')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (8, 7, 6, N'Sammy', N'Frank', CAST(N'2003-01-01T00:00:00.0000000' AS DateTime2), N'ID7')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (9, NULL, NULL, N'John', N'Frank', CAST(N'2004-01-01T00:00:00.0000000' AS DateTime2), N'ID8')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (10, NULL, NULL, N'Samantha', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID9')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (11, 7, 6, N'Johnny', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID10')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (12, 26, 27, N'Lily', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID11')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (13, 12, 11, N'Lileth', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID12')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (14, NULL, NULL, N'Lola', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID13')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (15, 5, 14, N'Lolitha', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID14')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (16, 5, 14, N'Frankie', N'Blank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID15')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (17, NULL, NULL, N'Frederik', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID16')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (18, 17, 15, N'Freddy', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID17')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (19, 17, 15, N'Renitha', N'Monk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID18')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (20, NULL, NULL, N'Rennie', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID19')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (21, 20, 4, N'Kenny', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID20')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (22, 20, 4, N'Sandra', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID21')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (23, 20, 4, N'Conrad', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID22')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (24, NULL, NULL, N'Harmony', N'Ronn', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID23')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (25, 23, 24, N'Harry', N'Van Wyk', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID24')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (26, NULL, NULL, N'Peter', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID25')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (27, NULL, NULL, N'Sendra', N'Frank', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID26')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (28, NULL, NULL, N'Adri', N'Shan', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID27')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (29, 18, 28, N'Adrina', N'Shan', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID28')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (30, NULL, NULL, N'Bakkies', N'Botha', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID29')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (31, 30, 29, N'Ronald', N'Botha', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID30')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (32, NULL, NULL, N'Keisha', N'McDonald', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID31')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (33, 31, 32, N'Keela', N'McDonald', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID32')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (34, NULL, NULL, N'Johan', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID33')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (35, 34, 33, N'Koolie', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID44')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (36, NULL, NULL, N'Jan-Hendrik', N'Human', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID45')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (37, 36, 35, N'Jannie', N'Human', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID46')
GO

INSERT [site].[Persons] ([Id], [FatherId], [MotherId], [Name], [Surname], [BirthDate], [IdentityNumber]) VALUES (39, 31, 32, N'Fannie', N'Fourie', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), N'ID47')
GO

SET IDENTITY_INSERT [site].[Persons] OFF
GO

/****** Object:  StoredProcedure [site].[GetDescendantsByIdentityNumber]    Script Date: 2024/01/07 02:03:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [site].[GetRootAscendantsByIdentityNumber]    Script Date: 2024/01/07 02:03:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET  READ_WRITE
GO

ALTER DATABASE [WhoIsMyGranddaddy] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)

GO

--Syntax Error: Incorrect syntax near WAIT_STATS_CAPTURE_MODE.
--ALTER DATABASE [WhoIsMyGranddaddy] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)



GO
