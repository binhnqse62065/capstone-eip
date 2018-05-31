CREATE TABLE [dbo].[InventoryDateReportItem] (
    [ItemID]                        INT NOT NULL,
    [Quantity]                      INT NOT NULL,
    [ReportID]                      INT NOT NULL,
    [ImportAmount]                  INT NULL,
    [ExportAmount]                  INT NULL,
    [CancelAmount]                  INT NULL,
    [SoldAmount]                    INT NULL,
    [ReturnAmount]                  INT NULL,
    [ChangeInventoryAmount]         INT NULL,
    [TheoryAmount]                  INT NULL,
    [RealAmount]                    INT NULL,
    [TotalExport]                   INT NULL,
    [TotalImport]                   INT NULL,
    [ReceivedChangeInventoryAmount] INT NULL,
    [IsSelected]                    BIT NULL,
    CONSTRAINT [PK__ReportIt__3F2557656FE99F9F] PRIMARY KEY CLUSTERED ([ItemID] ASC, [ReportID] ASC),
    CONSTRAINT [FK__ReportIte__ItemI__55009F39] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ProductItem] ([ItemID]),
    CONSTRAINT [FK_ReportItem_InventoryReport] FOREIGN KEY ([ReportID]) REFERENCES [dbo].[InventoryDateReport] ([ReportID])
);

