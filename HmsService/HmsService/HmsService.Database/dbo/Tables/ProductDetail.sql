CREATE TABLE [dbo].[ProductDetail] (
    [ProductDetailID] INT IDENTITY (1, 1) NOT NULL,
    [ProductID]       INT NULL,
    [StoreID]         INT NULL,
    [Price]           INT NULL,
    [DiscountPercent] INT NULL,
    CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED ([ProductDetailID] ASC),
    CONSTRAINT [FK_ProductDetail_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_ProductDetail_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID])
);

