CREATE TABLE [dbo].[ProductItem] (
    [ItemID]      INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [ItemName]    NVARCHAR (50)  NULL,
    [Unit]        NVARCHAR (50)  NULL,
    [IsAvailable] BIT            NULL,
    [ImageUrl]    NVARCHAR (100) NULL,
    [CatID]       INT            NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_ProductItem_ItemCategory] FOREIGN KEY ([CatID]) REFERENCES [dbo].[ItemCategory] ([CateID])
);

