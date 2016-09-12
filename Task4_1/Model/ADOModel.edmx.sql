
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/12/2016 18:32:12
-- Generated from EDMX file: S:\Visual Studio 2015\Projects\My-Training\Task4_1\Model\ADOModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [model];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MainCategories'
CREATE TABLE [dbo].[MainCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MainCategorieId] int  NOT NULL
);
GO

-- Creating table 'SubCategories'
CREATE TABLE [dbo].[SubCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategorieId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LinkId] nvarchar(max)  NOT NULL,
    [Advertiser] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [SubCategorieId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MainCategories'
ALTER TABLE [dbo].[MainCategories]
ADD CONSTRAINT [PK_MainCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubCategories'
ALTER TABLE [dbo].[SubCategories]
ADD CONSTRAINT [PK_SubCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MainCategorieId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_MainCategorieCategorie]
    FOREIGN KEY ([MainCategorieId])
    REFERENCES [dbo].[MainCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MainCategorieCategorie'
CREATE INDEX [IX_FK_MainCategorieCategorie]
ON [dbo].[Categories]
    ([MainCategorieId]);
GO

-- Creating foreign key on [CategorieId] in table 'SubCategories'
ALTER TABLE [dbo].[SubCategories]
ADD CONSTRAINT [FK_CategorieSubCategorie]
    FOREIGN KEY ([CategorieId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategorieSubCategorie'
CREATE INDEX [IX_FK_CategorieSubCategorie]
ON [dbo].[SubCategories]
    ([CategorieId]);
GO

-- Creating foreign key on [SubCategorieId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_SubCategorieProduct]
    FOREIGN KEY ([SubCategorieId])
    REFERENCES [dbo].[SubCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubCategorieProduct'
CREATE INDEX [IX_FK_SubCategorieProduct]
ON [dbo].[Products]
    ([SubCategorieId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------