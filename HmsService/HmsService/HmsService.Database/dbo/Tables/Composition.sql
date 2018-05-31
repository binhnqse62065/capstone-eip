CREATE TABLE [dbo].[Composition] (
    [ProducID] INT        NOT NULL,
    [ItemID]   INT        NOT NULL,
    [Quantity] FLOAT (53) NOT NULL,
    CONSTRAINT [PK_Composition_1] PRIMARY KEY CLUSTERED ([ProducID] ASC, [ItemID] ASC),
    CONSTRAINT [FK__Compositi__ItemI__76969D2E] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ProductItem] ([ItemID]),
    CONSTRAINT [FK__Compositi__Produ__778AC167] FOREIGN KEY ([ProducID]) REFERENCES [dbo].[Product] ([ProductID])
);

