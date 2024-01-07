﻿/*
Deployment script for WhoIsMyGranddaddy.Tests

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "WhoIsMyGranddaddy.Tests"
:setvar DefaultFilePrefix "WhoIsMyGranddaddy.Tests"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating Schema [site]...';


GO
CREATE SCHEMA [site]
    AUTHORIZATION [dbo];


GO
PRINT N'Creating Table [site].[Persons]...';


GO
CREATE TABLE [site].[Persons] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [FatherId]       INT            NULL,
    [MotherId]       INT            NULL,
    [Name]           NVARCHAR (MAX) NOT NULL,
    [Surname]        NVARCHAR (MAX) NOT NULL,
    [BirthDate]      DATETIME2 (7)  NOT NULL,
    [IdentityNumber] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Creating Index [site].[Persons].[IX_Persons_FatherId]...';


GO
CREATE NONCLUSTERED INDEX [IX_Persons_FatherId]
    ON [site].[Persons]([FatherId] ASC)
    ON [PRIMARY];


GO
PRINT N'Creating Index [site].[Persons].[IX_Persons_MotherId]...';


GO
CREATE NONCLUSTERED INDEX [IX_Persons_MotherId]
    ON [site].[Persons]([MotherId] ASC)
    ON [PRIMARY];


GO
PRINT N'Creating Table [dbo].[__EFMigrationsHistory]...';


GO
CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Foreign Key [site].[FK_Persons_Persons_FatherId]...';


GO
ALTER TABLE [site].[Persons]
    ADD CONSTRAINT [FK_Persons_Persons_FatherId] FOREIGN KEY ([FatherId]) REFERENCES [site].[Persons] ([Id]);


GO
PRINT N'Creating Foreign Key [site].[FK_Persons_Persons_MotherId]...';


GO
ALTER TABLE [site].[Persons]
    ADD CONSTRAINT [FK_Persons_Persons_MotherId] FOREIGN KEY ([MotherId]) REFERENCES [site].[Persons] ([Id]);


GO
PRINT N'Creating Procedure [site].[GetRootAscendantsByIdentityNumber]...';


GO
CREATE PROCEDURE [site].[GetRootAscendantsByIdentityNumber]
    @IdentityNumber NVARCHAR(MAX)
AS
BEGIN
    WITH RecursiveAscendants AS (
        SELECT
            Id,
            FatherId,
            MotherId,
            Name,
            Surname,
            BirthDate,
            IdentityNumber
        FROM
            [site].[Persons]
        WHERE
            IdentityNumber = @IdentityNumber
        UNION ALL
        SELECT
            p.Id,
            p.FatherId,
            p.MotherId,
            p.Name,
            p.Surname,
            p.BirthDate,
            p.IdentityNumber
        FROM
            [site].[Persons] p
        INNER JOIN
            RecursiveAscendants ra ON ra.FatherId = p.Id OR ra.MotherId = p.Id
    )
    SELECT
        DISTINCT Id,
        FatherId,
        MotherId,
        Name,
        Surname,
        BirthDate,
        IdentityNumber
    FROM
        RecursiveAscendants
    WHERE
        (FatherId IS NULL OR MotherId IS NULL)
    ORDER BY
        BirthDate ASC;
END
GO
PRINT N'Creating Procedure [site].[GetDescendantsByIdentityNumber]...';


GO
/*
	DECLARE @MaxPages INT
	EXEC [site].[GetDescendantsByIdentityNumber] 'ID33', 8, 1, @MaxPages

	select * from site.Persons
*/
CREATE PROCEDURE [site].[GetDescendantsByIdentityNumber]
    @IdentityNumber NVARCHAR(MAX) = NULL,
    @PageSize INT = 10,
    @PageNumber INT = 1,
    @MaxPages INT OUTPUT
AS
BEGIN
    -- Temporary table to store RecursiveDescendants results
    CREATE TABLE #TempRecursiveDescendants (
	RowNum INT,
        Id INT,
        FatherId INT,
        MotherId INT,
        Name NVARCHAR(MAX),
        Surname NVARCHAR(MAX),
        BirthDate DATE,
        IdentityNumber NVARCHAR(MAX),
		PartnerId INT
    );

;WITH RecursiveDescendants AS (
    SELECT
        Id,
        FatherId,
        MotherId,
        Name,
        Surname,
        BirthDate,
        IdentityNumber,
        1 AS RowNum  -- Starting with 1 for the anchor member
    FROM
        [site].[Persons]
    WHERE
        @IdentityNumber IS NULL OR IdentityNumber = @IdentityNumber
    UNION ALL
    SELECT
        p.Id,
        p.FatherId,
        p.MotherId,
        p.Name,
        p.Surname,
        p.BirthDate,
        p.IdentityNumber,
        rd.RowNum + 1  -- Increment the row number in the recursive part
    FROM
        [site].[Persons] p
    INNER JOIN
        RecursiveDescendants rd ON rd.Id = p.FatherId OR rd.Id = p.MotherId
)


    
    -- Insert into temporary table
    -- Insert into temporary table with PartnerId column
    INSERT INTO #TempRecursiveDescendants (Id, FatherId, MotherId, Name, Surname, BirthDate, IdentityNumber, PartnerId)
    SELECT 
        rd.Id,
        CASE WHEN (@IdentityNumber IS NOT NULL AND rd.RowNum = 1 AND @PageNumber = 1) THEN NULL ELSE rd.FatherId END AS FatherId,
        CASE WHEN (@IdentityNumber IS NOT NULL AND rd.RowNum = 1 AND @PageNumber = 1) THEN NULL ELSE rd.MotherId END AS MotherId,
        rd.Name,
        rd.Surname,
        rd.BirthDate,
        rd.IdentityNumber,
        COALESCE(
            CASE WHEN m.MotherId = rd.Id THEN m.FatherId END,
            CASE WHEN f.FatherId = rd.Id THEN f.MotherId END
        ) AS PartnerId
    FROM 
        RecursiveDescendants rd
    LEFT JOIN 
        [site].[Persons] m ON m.MotherId = rd.Id
	LEFT JOIN 
        [site].[Persons] f ON f.FatherId = rd.Id;

    -- Calculate Max Pages
    SELECT @MaxPages = CEILING(COUNT(DISTINCT(Id)) / CAST(@PageSize AS FLOAT))
    FROM #TempRecursiveDescendants
    WHERE @IdentityNumber IS NULL OR 1 = 1;

    -- Fetch Paged Results
    SELECT
		DISTINCT(Id),
		RowNum,
        FatherId,
        MotherId,
        Name,
        Surname,
        BirthDate,
        IdentityNumber,
		PartnerId
    FROM
        #TempRecursiveDescendants
    WHERE @IdentityNumber IS NULL OR 1 = 1
    ORDER BY Id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    -- Drop temporary table
    DROP TABLE #TempRecursiveDescendants;
END
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO