
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/22/2017 15:26:05
-- Generated from EDMX file: S:\Visual Studio 2015\Projects\My-Training\Task5\DAL\EntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PurchasesApp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_ManagerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_ProductOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[PurchasesAppModelStoreContainer].[vOrders]', 'U') IS NOT NULL
    DROP TABLE [PurchasesAppModelStoreContainer].[vOrders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [ManagerId] int  NOT NULL,
    [CustomerId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'vOrders'
CREATE TABLE [dbo].[vOrders] (
    [OrderId] int  NOT NULL,
    [PurchaseDate] datetime  NOT NULL,
    [ManagerId] int  NOT NULL,
    [ManagerName] nvarchar(max)  NOT NULL,
    [CustomerId] int  NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL,
    [ProductId] int  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [OrderId], [PurchaseDate], [ManagerId], [ManagerName], [CustomerId], [CustomerName], [ProductId], [ProductName], [Amount] in table 'vOrders'
ALTER TABLE [dbo].[vOrders]
ADD CONSTRAINT [PK_vOrders]
    PRIMARY KEY CLUSTERED ([OrderId], [PurchaseDate], [ManagerId], [ManagerName], [CustomerId], [CustomerName], [ProductId], [ProductName], [Amount] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[OrderSet]
    ([CustomerId]);
GO

-- Creating foreign key on [ManagerId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_ManagerOrder]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerOrder'
CREATE INDEX [IX_FK_ManagerOrder]
ON [dbo].[OrderSet]
    ([ManagerId]);
GO

-- Creating foreign key on [ProductId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_ProductOrder]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOrder'
CREATE INDEX [IX_FK_ProductOrder]
ON [dbo].[OrderSet]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------