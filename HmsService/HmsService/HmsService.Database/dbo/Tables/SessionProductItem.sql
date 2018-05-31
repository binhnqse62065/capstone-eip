CREATE TABLE [dbo].[SessionProductItem] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [SessionID]       INT           NOT NULL,
    [ProductItemID]   INT           NOT NULL,
    [ProductItemName] NVARCHAR (50) NULL,
    [Quantity]        INT           NOT NULL,
    [Unit]            NVARCHAR (20) NULL,
    CONSTRAINT [PK_SessionProductItem] PRIMARY KEY CLUSTERED ([ID] ASC)
);

