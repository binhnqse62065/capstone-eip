CREATE TABLE [dbo].[CustomerProduct] (
    [ID]            INT      IDENTITY (1, 1) NOT NULL,
    [CustomerID]    INT      NOT NULL,
    [ProductID]     INT      NOT NULL,
    [TotalQuantity] INT      NOT NULL,
    [UpdateDate]    DATETIME NOT NULL,
    CONSTRAINT [PK_CustomerProduct] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CustomerProduct_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_CustomerProduct_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);

