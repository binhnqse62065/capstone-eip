CREATE TABLE [dbo].[ProductCategory] (
    [CateID]         INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CateName]       NVARCHAR (50)  NOT NULL,
    [Type]           INT            CONSTRAINT [DF_ProductCategory_Type] DEFAULT ((1)) NOT NULL,
    [IsDisplayed]    BIT            CONSTRAINT [DF_ProductCategory_IsDisplayed] DEFAULT ((1)) NOT NULL,
    [IsExtra]        BIT            NOT NULL,
    [DisplayOrder]   INT            NOT NULL,
    [AdjustmentNote] NVARCHAR (250) NULL,
    [StoreId]        INT            NULL,
    PRIMARY KEY CLUSTERED ([CateID] ASC),
    CONSTRAINT [FK_ProductCategory_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

