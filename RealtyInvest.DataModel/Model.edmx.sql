
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/12/2014 18:13:26
-- Generated from EDMX file: D:\projects\RealtyInvest\RealtyInvest.DataModel\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [realtyinvest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OwnerRealEstate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RealEstateSet] DROP CONSTRAINT [FK_OwnerRealEstate];
GO
IF OBJECT_ID(N'[dbo].[FK_InvestorTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_InvestorTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_RealEstateTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionSet] DROP CONSTRAINT [FK_RealEstateTransaction];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RealEstateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RealEstateSet];
GO
IF OBJECT_ID(N'[dbo].[TransactionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionSet];
GO
IF OBJECT_ID(N'[dbo].[OwnerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OwnerSet];
GO
IF OBJECT_ID(N'[dbo].[InvestorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvestorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RealEstateSet'
CREATE TABLE [dbo].[RealEstateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Coordinates_x] float  NOT NULL,
    [Coordinates_y] float  NOT NULL,
    [Square] nvarchar(max)  NOT NULL,
    [Polygon] geometry  NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Owner_Id] int  NOT NULL
);
GO

-- Creating table 'TransactionSet'
CREATE TABLE [dbo].[TransactionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] nvarchar(max)  NOT NULL,
    [Type] tinyint  NOT NULL,
    [Date] datetime  NOT NULL,
    [Investor_Id] int  NOT NULL,
    [RealEstate_Id] int  NOT NULL
);
GO

-- Creating table 'OwnerSet'
CREATE TABLE [dbo].[OwnerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InvestorSet'
CREATE TABLE [dbo].[InvestorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RealEstateSet'
ALTER TABLE [dbo].[RealEstateSet]
ADD CONSTRAINT [PK_RealEstateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [PK_TransactionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OwnerSet'
ALTER TABLE [dbo].[OwnerSet]
ADD CONSTRAINT [PK_OwnerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvestorSet'
ALTER TABLE [dbo].[InvestorSet]
ADD CONSTRAINT [PK_InvestorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Owner_Id] in table 'RealEstateSet'
ALTER TABLE [dbo].[RealEstateSet]
ADD CONSTRAINT [FK_OwnerRealEstate]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[OwnerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerRealEstate'
CREATE INDEX [IX_FK_OwnerRealEstate]
ON [dbo].[RealEstateSet]
    ([Owner_Id]);
GO

-- Creating foreign key on [Investor_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_InvestorTransaction]
    FOREIGN KEY ([Investor_Id])
    REFERENCES [dbo].[InvestorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvestorTransaction'
CREATE INDEX [IX_FK_InvestorTransaction]
ON [dbo].[TransactionSet]
    ([Investor_Id]);
GO

-- Creating foreign key on [RealEstate_Id] in table 'TransactionSet'
ALTER TABLE [dbo].[TransactionSet]
ADD CONSTRAINT [FK_RealEstateTransaction]
    FOREIGN KEY ([RealEstate_Id])
    REFERENCES [dbo].[RealEstateSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RealEstateTransaction'
CREATE INDEX [IX_FK_RealEstateTransaction]
ON [dbo].[TransactionSet]
    ([RealEstate_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------