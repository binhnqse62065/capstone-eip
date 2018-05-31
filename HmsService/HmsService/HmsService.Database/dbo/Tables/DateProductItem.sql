CREATE TABLE [dbo].[DateProductItem] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [Date]            DATETIME      NOT NULL,
    [ProductItemID]   INT           NOT NULL,
    [ProductItemName] NVARCHAR (50) NULL,
    [Quantity]        INT           NOT NULL,
    [Unit]            NVARCHAR (20) NULL,
    [StoreId]         INT           NULL,
    CONSTRAINT [PK_DateProductItem] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_DateProductItem_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

