CREATE TABLE [dbo].[ProductExtra] (
    [ProductID]      INT NOT NULL,
    [ExtraProductID] INT NOT NULL,
    [IsDisplayed]    BIT NULL,
    [MaxItem]        INT NULL,
    [Price]          INT NULL,
    CONSTRAINT [PK_ProductExtra] PRIMARY KEY CLUSTERED ([ProductID] ASC, [ExtraProductID] ASC),
    CONSTRAINT [FK_ProductExtra_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_ProductExtra_Product1] FOREIGN KEY ([ExtraProductID]) REFERENCES [dbo].[Product] ([ProductID])
);

