
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2018 23:10:23
-- Generated from EDMX file: D:\FED_RESERVE_2\STUDY_PC\ТРПО\interYOURMOMface\interYOURMOMface\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mahmad_credit];
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

-- Creating table 'card'
CREATE TABLE [dbo].[card] (
    [card_id] int IDENTITY(1,1) NOT NULL,
    [IL] nvarchar(max)  NOT NULL,
    [card_type] nvarchar(max)  NOT NULL,
    [system_code] nvarchar(max)  NOT NULL,
    [bank_code] nvarchar(max)  NOT NULL,
    [bill_number] nvarchar(max)  NOT NULL,
    [check_number] nvarchar(max)  NOT NULL,
    [cvv] nvarchar(max)  NOT NULL,
    [card_start] datetime  NOT NULL,
    [card_end] datetime  NOT NULL,
    [check_word] nchar(50)  NOT NULL
);
GO

-- Creating table 'customer'
CREATE TABLE [dbo].[customer] (
    [customer_id] int IDENTITY(1,1) NOT NULL,
    [fio] nchar(50)  NOT NULL,
    [passport_number] nvarchar(max)  NOT NULL,
    [passport_date] datetime  NOT NULL,
    [passport_info] nchar(150)  NOT NULL,
    [sex] nchar(150)  NOT NULL,
    [family_status] nchar(10)  NOT NULL,
    [birthdate] datetime  NOT NULL,
    [tel_number] nvarchar(max)  NOT NULL,
    [email] char(50)  NOT NULL,
    [education] nchar(50)  NOT NULL,
    [education_place_code] nvarchar(max)  NOT NULL,
    [live_place] nchar(100)  NOT NULL,
    [work_place] nchar(100)  NOT NULL,
    [work_tel_number] nvarchar(max)  NOT NULL,
    [work_post] nchar(50)  NOT NULL,
    [month_income] nvarchar(max)  NOT NULL,
    [credit_reason] nchar(50)  NOT NULL
);
GO

-- Creating table 'credit'
CREATE TABLE [dbo].[credit] (
    [credit_number] int IDENTITY(1,1) NOT NULL,
    [percent_set] nvarchar(max)  NOT NULL,
    [currency] char(10)  NOT NULL,
    [credit_start] datetime  NOT NULL,
    [credit_end] datetime  NOT NULL,
    [remainer] nvarchar(max)  NOT NULL,
    [sum] nvarchar(max)  NOT NULL,
    [month_sum] nvarchar(max)  NOT NULL,
    [months] nvarchar(max)  NOT NULL,
    [card_card_id] int  NOT NULL,
    [customer_customer_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [card_id] in table 'card'
ALTER TABLE [dbo].[card]
ADD CONSTRAINT [PK_card]
    PRIMARY KEY CLUSTERED ([card_id] ASC);
GO

-- Creating primary key on [customer_id] in table 'customer'
ALTER TABLE [dbo].[customer]
ADD CONSTRAINT [PK_customer]
    PRIMARY KEY CLUSTERED ([customer_id] ASC);
GO

-- Creating primary key on [credit_number] in table 'credit'
ALTER TABLE [dbo].[credit]
ADD CONSTRAINT [PK_credit]
    PRIMARY KEY CLUSTERED ([credit_number] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [card_card_id] in table 'credit'
ALTER TABLE [dbo].[credit]
ADD CONSTRAINT [FK_creditcard]
    FOREIGN KEY ([card_card_id])
    REFERENCES [dbo].[card]
        ([card_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_creditcard'
CREATE INDEX [IX_FK_creditcard]
ON [dbo].[credit]
    ([card_card_id]);
GO

-- Creating foreign key on [customer_customer_id] in table 'credit'
ALTER TABLE [dbo].[credit]
ADD CONSTRAINT [FK_creditcustomer]
    FOREIGN KEY ([customer_customer_id])
    REFERENCES [dbo].[customer]
        ([customer_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_creditcustomer'
CREATE INDEX [IX_FK_creditcustomer]
ON [dbo].[credit]
    ([customer_customer_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------