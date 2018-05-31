CREATE TABLE [dbo].[WebMenuCategory] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [IsMenuSystem] BIT            CONSTRAINT [DF_WebMenuCategory_IsMenuSystem] DEFAULT ((0)) NOT NULL,
    [StoreId]      INT            NOT NULL,
    CONSTRAINT [PK_WebMenuCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WebMenuCategory_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

