CREATE TABLE [dbo].[InventoryReceipt] (
    [ReceiptID]     INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [ChangeDate]    DATETIME       NOT NULL,
    [ReceiptType]   INT            NOT NULL,
    [Status]        INT            CONSTRAINT [DF_InventoryReceipt_IsApproved] DEFAULT ((0)) NOT NULL,
    [Notes]         NVARCHAR (255) NULL,
    [Name]          NVARCHAR (255) NULL,
    [Creator]       NVARCHAR (MAX) NULL,
    [StoreId]       INT            NULL,
    [InStoreId]     INT            NULL,
    [OutStoreId]    INT            NULL,
    [ProviderId]    INT            NULL,
    [CreateDate]    DATETIME       NULL,
    [InvoiceNumber] NVARCHAR (255) NULL,
    CONSTRAINT [PK_InventoryReceipt] PRIMARY KEY CLUSTERED ([ReceiptID] ASC),
    CONSTRAINT [FK_InventoryReceipt_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[Provider] ([Id]),
    CONSTRAINT [FK_InventoryReceipt_Store3] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID]),
    CONSTRAINT [FK_InventoryReceipt_Store4] FOREIGN KEY ([InStoreId]) REFERENCES [dbo].[Store] ([ID]),
    CONSTRAINT [FK_InventoryReceipt_Store5] FOREIGN KEY ([OutStoreId]) REFERENCES [dbo].[Store] ([ID])
);

