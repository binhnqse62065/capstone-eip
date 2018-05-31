CREATE TABLE [dbo].[CategoryPriceGroup] (
    [CategoryID]   INT NOT NULL,
    [PriceGroupID] INT NOT NULL,
    [IsDefault]    BIT NOT NULL,
    CONSTRAINT [PK_CategoryPriceGroup] PRIMARY KEY CLUSTERED ([CategoryID] ASC, [PriceGroupID] ASC),
    CONSTRAINT [FK_CategoryPriceGroup_PriceGroup] FOREIGN KEY ([PriceGroupID]) REFERENCES [dbo].[PriceGroup] ([PriceGroupID]),
    CONSTRAINT [FK_CategoryPriceGroup_RoomCategory] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[RoomCategory] ([CategoryID])
);

