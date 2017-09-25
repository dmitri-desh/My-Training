
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/25/2017 16:28:12
-- Generated from EDMX file: S:\Visual Studio 2015\Projects\My-Training\IntraVisionTask\IntraVisionTask\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
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

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Picture] varbinary(max)  NOT NULL
);
GO

-- Creating table 'ProdLoads'
CREATE TABLE [dbo].[ProdLoads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cnt] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [OperationId] int  NOT NULL
);
GO

-- Creating table 'CoinLoads'
CREATE TABLE [dbo].[CoinLoads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cnt] int  NOT NULL,
    [CoinTypeId] int  NOT NULL,
    [OperationId] int  NOT NULL
);
GO

-- Creating table 'CoinTypes'
CREATE TABLE [dbo].[CoinTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dignity] smallint  NOT NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sign] smallint  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [OrderCoinId] int  NOT NULL
);
GO

-- Creating table 'OrderCoins'
CREATE TABLE [dbo].[OrderCoins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CoinTypeId] int  NOT NULL,
    [Cnt] smallint  NOT NULL,
    [OrderId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdLoads'
ALTER TABLE [dbo].[ProdLoads]
ADD CONSTRAINT [PK_ProdLoads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoinLoads'
ALTER TABLE [dbo].[CoinLoads]
ADD CONSTRAINT [PK_CoinLoads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoinTypes'
ALTER TABLE [dbo].[CoinTypes]
ADD CONSTRAINT [PK_CoinTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderCoins'
ALTER TABLE [dbo].[OrderCoins]
ADD CONSTRAINT [PK_OrderCoins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductId] in table 'ProdLoads'
ALTER TABLE [dbo].[ProdLoads]
ADD CONSTRAINT [FK_ProductProdLoad]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProdLoad'
CREATE INDEX [IX_FK_ProductProdLoad]
ON [dbo].[ProdLoads]
    ([ProductId]);
GO

-- Creating foreign key on [CoinTypeId] in table 'CoinLoads'
ALTER TABLE [dbo].[CoinLoads]
ADD CONSTRAINT [FK_CoinTypeCoinLoad]
    FOREIGN KEY ([CoinTypeId])
    REFERENCES [dbo].[CoinTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoinTypeCoinLoad'
CREATE INDEX [IX_FK_CoinTypeCoinLoad]
ON [dbo].[CoinLoads]
    ([CoinTypeId]);
GO

-- Creating foreign key on [OperationId] in table 'CoinLoads'
ALTER TABLE [dbo].[CoinLoads]
ADD CONSTRAINT [FK_OperationCoinLoad]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationCoinLoad'
CREATE INDEX [IX_FK_OperationCoinLoad]
ON [dbo].[CoinLoads]
    ([OperationId]);
GO

-- Creating foreign key on [OperationId] in table 'ProdLoads'
ALTER TABLE [dbo].[ProdLoads]
ADD CONSTRAINT [FK_OperationProdLoad]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationProdLoad'
CREATE INDEX [IX_FK_OperationProdLoad]
ON [dbo].[ProdLoads]
    ([OperationId]);
GO

-- Creating foreign key on [ProductId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_ProductOrder]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOrder'
CREATE INDEX [IX_FK_ProductOrder]
ON [dbo].[Orders]
    ([ProductId]);
GO

-- Creating foreign key on [CoinTypeId] in table 'OrderCoins'
ALTER TABLE [dbo].[OrderCoins]
ADD CONSTRAINT [FK_CoinTypeOrderCoin]
    FOREIGN KEY ([CoinTypeId])
    REFERENCES [dbo].[CoinTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoinTypeOrderCoin'
CREATE INDEX [IX_FK_CoinTypeOrderCoin]
ON [dbo].[OrderCoins]
    ([CoinTypeId]);
GO

-- Creating foreign key on [OrderCoinId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderCoinOrder]
    FOREIGN KEY ([OrderCoinId])
    REFERENCES [dbo].[OrderCoins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCoinOrder'
CREATE INDEX [IX_FK_OrderCoinOrder]
ON [dbo].[Orders]
    ([OrderCoinId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------