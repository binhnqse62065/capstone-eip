CREATE TABLE [dbo].[RoomCategory] (
    [CategoryID]   INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50)  NOT NULL,
    [IconUrl]      NVARCHAR (200) NOT NULL,
    [ShortNane]    VARCHAR (10)   NOT NULL,
    [Priority]     INT            NOT NULL,
    [StoreID]      INT            NULL,
    [IsDelete]     BIT            NULL,
    CONSTRAINT [PK_RoomCategory] PRIMARY KEY CLUSTERED ([CategoryID] ASC),
    CONSTRAINT [FK_RoomCategory_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID])
);

