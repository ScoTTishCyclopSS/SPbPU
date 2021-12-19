
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2019 13:39:17
-- Generated from EDMX file: D:\FED_RESERVE_2\STUDY_PC\practice_2019\project\music_store\music_store\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [music_store];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_categoriesproducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[products] DROP CONSTRAINT [FK_categoriesproducts];
GO
IF OBJECT_ID(N'[dbo].[FK_productslots]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lots] DROP CONSTRAINT [FK_productslots];
GO
IF OBJECT_ID(N'[dbo].[FK_productssales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sales] DROP CONSTRAINT [FK_productssales];
GO
IF OBJECT_ID(N'[dbo].[FK_providerslots]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[lots] DROP CONSTRAINT [FK_providerslots];
GO
IF OBJECT_ID(N'[dbo].[FK_sellerssales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sales] DROP CONSTRAINT [FK_sellerssales];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categories];
GO
IF OBJECT_ID(N'[dbo].[lots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[lots];
GO
IF OBJECT_ID(N'[dbo].[products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[products];
GO
IF OBJECT_ID(N'[dbo].[providers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[providers];
GO
IF OBJECT_ID(N'[dbo].[sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sales];
GO
IF OBJECT_ID(N'[dbo].[sellers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sellers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'lots'
CREATE TABLE [dbo].[lots] (
    [id] int IDENTITY(1,1) NOT NULL,
    [count] int  NOT NULL,
    [cost] nvarchar(50)  NOT NULL,
    [date] datetime  NOT NULL,
    [providers_id] int  NOT NULL,
    [products_id] int  NOT NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [count] int  NOT NULL,
    [weigh] float  NOT NULL,
    [price] nvarchar(50)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [image] varbinary(max)  NULL,
    [categories_id] int  NOT NULL
);
GO

-- Creating table 'providers'
CREATE TABLE [dbo].[providers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [manufacturer] nvarchar(50)  NOT NULL,
    [address] nvarchar(50)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [tel_number] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'sales'
CREATE TABLE [dbo].[sales] (
    [id] int IDENTITY(1,1) NOT NULL,
    [count] int  NOT NULL,
    [total_cost] nvarchar(50)  NOT NULL,
    [date] datetime  NOT NULL,
    [sellers_id] int  NOT NULL,
    [products_id] int  NOT NULL
);
GO

-- Creating table 'sellers'
CREATE TABLE [dbo].[sellers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fio] nvarchar(50)  NOT NULL,
    [passport_info] nvarchar(50)  NOT NULL,
    [log_in] nvarchar(50)  NULL,
    [pass_word] nvarchar(50)  NULL,
    [role] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'categories'
ALTER TABLE [dbo].[categories]
ADD CONSTRAINT [PK_categories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'lots'
ALTER TABLE [dbo].[lots]
ADD CONSTRAINT [PK_lots]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'providers'
ALTER TABLE [dbo].[providers]
ADD CONSTRAINT [PK_providers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'sales'
ALTER TABLE [dbo].[sales]
ADD CONSTRAINT [PK_sales]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'sellers'
ALTER TABLE [dbo].[sellers]
ADD CONSTRAINT [PK_sellers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categories_id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_categoriesproducts]
    FOREIGN KEY ([categories_id])
    REFERENCES [dbo].[categories]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categoriesproducts'
CREATE INDEX [IX_FK_categoriesproducts]
ON [dbo].[products]
    ([categories_id]);
GO

-- Creating foreign key on [products_id] in table 'lots'
ALTER TABLE [dbo].[lots]
ADD CONSTRAINT [FK_productslots]
    FOREIGN KEY ([products_id])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productslots'
CREATE INDEX [IX_FK_productslots]
ON [dbo].[lots]
    ([products_id]);
GO

-- Creating foreign key on [providers_id] in table 'lots'
ALTER TABLE [dbo].[lots]
ADD CONSTRAINT [FK_providerslots]
    FOREIGN KEY ([providers_id])
    REFERENCES [dbo].[providers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_providerslots'
CREATE INDEX [IX_FK_providerslots]
ON [dbo].[lots]
    ([providers_id]);
GO

-- Creating foreign key on [products_id] in table 'sales'
ALTER TABLE [dbo].[sales]
ADD CONSTRAINT [FK_productssales]
    FOREIGN KEY ([products_id])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productssales'
CREATE INDEX [IX_FK_productssales]
ON [dbo].[sales]
    ([products_id]);
GO

-- Creating foreign key on [sellers_id] in table 'sales'
ALTER TABLE [dbo].[sales]
ADD CONSTRAINT [FK_sellerssales]
    FOREIGN KEY ([sellers_id])
    REFERENCES [dbo].[sellers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_sellerssales'
CREATE INDEX [IX_FK_sellerssales]
ON [dbo].[sales]
    ([sellers_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------