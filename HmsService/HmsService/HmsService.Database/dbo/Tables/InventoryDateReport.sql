CREATE TABLE [dbo].[InventoryDateReport] (
    [ReportID]   INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [StoreId]    INT            NOT NULL,
    [CreateDate] DATETIME       NOT NULL,
    [Creator]    NVARCHAR (128) NOT NULL,
    [Status]     INT            NOT NULL,
    CONSTRAINT [PK_InventoryReport] PRIMARY KEY CLUSTERED ([ReportID] ASC),
    CONSTRAINT [FK_InventoryReport_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

