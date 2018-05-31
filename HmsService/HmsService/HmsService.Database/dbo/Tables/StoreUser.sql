CREATE TABLE [dbo].[StoreUser] (
    [Username] NVARCHAR (256) NOT NULL,
    [StoreId]  INT            NOT NULL,
    CONSTRAINT [PK_StoreUser] PRIMARY KEY CLUSTERED ([Username] ASC, [StoreId] ASC),
    CONSTRAINT [FK_StoreUser_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

