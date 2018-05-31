CREATE TABLE [dbo].[ComboDetail] (
    [ComboID]   INT NOT NULL,
    [ProductID] INT NOT NULL,
    [Quantity]  INT NOT NULL,
    CONSTRAINT [PK_ComboDetail] PRIMARY KEY CLUSTERED ([ComboID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_ComboDetail_Product] FOREIGN KEY ([ComboID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_ComboDetail_Product1] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);

