
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2019 21:00:17
-- Generated from EDMX file: D:\FED_RESERVE_2\STUDY_PC\DIPLOMA\clothing_repair\clothing_repair\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [clothing_repair];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_categoriesorder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order] DROP CONSTRAINT [FK_categoriesorder];
GO
IF OBJECT_ID(N'[dbo].[FK_customerorder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order] DROP CONSTRAINT [FK_customerorder];
GO
IF OBJECT_ID(N'[dbo].[FK_userorder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[order] DROP CONSTRAINT [FK_userorder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categories];
GO
IF OBJECT_ID(N'[dbo].[customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[customer];
GO
IF OBJECT_ID(N'[dbo].[order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [category] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'customer'
CREATE TABLE [dbo].[customer] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [mail] nvarchar(50)  NOT NULL,
    [tel] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'order'
CREATE TABLE [dbo].[order] (
    [id] int IDENTITY(1,1) NOT NULL,
    [price] nvarchar(50)  NOT NULL,
    [date_of_receipt] datetime  NOT NULL,
    [date_of_give] datetime  NULL,
    [status] nvarchar(50)  NULL,
    [who_issued] nvarchar(50)  NULL,
    [categories_id] int  NOT NULL,
    [customer_id] int  NOT NULL,
    [user_id] int  NOT NULL
);
GO

-- Creating table 'user'
CREATE TABLE [dbo].[user] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(50)  NOT NULL,
    [role] nvarchar(50)  NOT NULL,
    [log_in] nvarchar(50)  NOT NULL,
    [pass_word] nvarchar(50)  NOT NULL
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

-- Creating primary key on [id] in table 'customer'
ALTER TABLE [dbo].[customer]
ADD CONSTRAINT [PK_customer]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'order'
ALTER TABLE [dbo].[order]
ADD CONSTRAINT [PK_order]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [PK_user]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categories_id] in table 'order'
ALTER TABLE [dbo].[order]
ADD CONSTRAINT [FK_categoriesorder]
    FOREIGN KEY ([categories_id])
    REFERENCES [dbo].[categories]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_categoriesorder'
CREATE INDEX [IX_FK_categoriesorder]
ON [dbo].[order]
    ([categories_id]);
GO

-- Creating foreign key on [customer_id] in table 'order'
ALTER TABLE [dbo].[order]
ADD CONSTRAINT [FK_customerorder]
    FOREIGN KEY ([customer_id])
    REFERENCES [dbo].[customer]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_customerorder'
CREATE INDEX [IX_FK_customerorder]
ON [dbo].[order]
    ([customer_id]);
GO

-- Creating foreign key on [user_id] in table 'order'
ALTER TABLE [dbo].[order]
ADD CONSTRAINT [FK_userorder]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[user]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_userorder'
CREATE INDEX [IX_FK_userorder]
ON [dbo].[order]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------