CREATE TABLE [dbo].[OrderFeeItem] (
    [OrderId]           INT            IDENTITY (1, 1) NOT NULL,
    [RentId]            INT            NOT NULL,
    [TotalAmount]       INT            NULL,
    [FinalAmount]       INT            NULL,
    [OrderDate]         DATETIME       NOT NULL,
    [DetailDescription] NVARCHAR (MAX) NULL,
    [Status]            INT            NULL,
    [CustomerID]        INT            NULL,
    [StoreId]           INT            NULL,
    [FromDate]          DATETIME       NULL,
    [ToDate]            DATETIME       NULL,
    [IsAddition]        BIT            NOT NULL,
    [ProductType]       INT            NULL,
    [RoomId]            INT            NULL,
    [RoomName]          NVARCHAR (MAX) NULL,
    [RentMode]          INT            NULL,
    [PriceGroupId]      INT            NULL,
    CONSTRAINT [PK_OrderFeeItem] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_OrderFeeItem_PriceGroup] FOREIGN KEY ([PriceGroupId]) REFERENCES [dbo].[PriceGroup] ([PriceGroupID]),
    CONSTRAINT [FK_OrderFeeItem_Rent] FOREIGN KEY ([RentId]) REFERENCES [dbo].[Rent] ([RentID])
);

