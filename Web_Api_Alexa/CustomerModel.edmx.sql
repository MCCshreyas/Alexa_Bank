
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2018 15:05:19
-- Generated from EDMX file: C:\Users\Shreyas.SHREYAS\source\repos\Alexa_Console\Web_Api_Alexa\CustomerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Alexa_Bank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Name] varchar(50)  NOT NULL,
    [Address] varchar(50)  NOT NULL,
    [Phone_number] varchar(50)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Balance] varchar(50)  NOT NULL,
    [Account_number] varchar(50)  NOT NULL,
    [ImagePath] varchar(50)  NOT NULL,
    [Gender] varchar(50)  NOT NULL,
    [BirthDate] varchar(50)  NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Name], [Address], [Phone_number], [Email], [Password], [Balance], [Account_number], [ImagePath], [Gender], [BirthDate], [ID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Name], [Address], [Phone_number], [Email], [Password], [Balance], [Account_number], [ImagePath], [Gender], [BirthDate], [ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------