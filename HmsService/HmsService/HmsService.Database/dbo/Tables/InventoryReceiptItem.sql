CREATE TABLE [dbo].[InventoryReceiptItem] (
    [ReceiptID] INT NOT NULL,
    [ItemID]    INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [PK_ReceiptItem] PRIMARY KEY CLUSTERED ([ReceiptID] ASC, [ItemID] ASC),
    CONSTRAINT [FK_ReceiptItem_InventoryReceipt] FOREIGN KEY ([ReceiptID]) REFERENCES [dbo].[InventoryReceipt] ([ReceiptID]),
    CONSTRAINT [FK_ReceiptItem_ProductItem] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ProductItem] ([ItemID])
);

