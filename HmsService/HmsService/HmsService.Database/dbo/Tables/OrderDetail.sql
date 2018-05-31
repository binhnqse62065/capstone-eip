CREATE TABLE [dbo].[OrderDetail] (
    [OrderID]           INT            IDENTITY (1, 1) NOT NULL,
    [RentID]            INT            NOT NULL,
    [ProductID]         INT            NOT NULL,
    [TotalAmount]       INT            NOT NULL,
    [Quantity]          INT            NOT NULL,
    [OrderDate]         DATETIME       NOT NULL,
    [Status]            INT            NOT NULL,
    [FinalAmount]       INT            CONSTRAINT [DF_OrderDetail_Discount] DEFAULT ((0)) NOT NULL,
    [IsAddition]        BIT            CONSTRAINT [DF_OrderDetail_IsAddition] DEFAULT ((1)) NOT NULL,
    [DetailDescription] NVARCHAR (MAX) NULL,
    [Discount]          INT            CONSTRAINT [DF_OrderDetail_DiscountPercent] DEFAULT ((0)) NOT NULL,
    [TaxPercent]        FLOAT (53)     NULL,
    [TaxValue]          INT            NULL,
    [UnitPrice]         INT            NULL,
    [ProductType]       INT            NULL,
    [ParentId]          INT            NULL,
    [StoreId]           AS             ([dbo].[CurrentOrderDetailStore]([RentID])),
    [ProductOrderType]  INT            NULL,
    [ItemQuantity]      INT            NOT NULL,
    CONSTRAINT [PK__OrderDetail__0662F0A3] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_OrderDetail_OrderDetail] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[OrderDetail] ([OrderID]),
    CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_OrderDetail_Rent] FOREIGN KEY ([RentID]) REFERENCES [dbo].[Rent] ([RentID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderDetail_RentID]
    ON [dbo].[OrderDetail]([RentID] ASC, [Quantity] ASC);

