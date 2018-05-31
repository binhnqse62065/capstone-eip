CREATE TABLE [dbo].[InventoryCheckingItem] (
    [InventoryCheckingID] INT           IDENTITY (1, 1) NOT NULL,
    [ItemID]              INT           NOT NULL,
    [CheckingId]          INT           NOT NULL,
    [Quantity]            FLOAT (53)    NOT NULL,
    [Unit]                NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_InventoryCheckingItem] PRIMARY KEY CLUSTERED ([InventoryCheckingID] ASC),
    CONSTRAINT [FK_InventoryCheckingItem_InventoryChecking] FOREIGN KEY ([CheckingId]) REFERENCES [dbo].[InventoryChecking] ([CheckingId])
);

