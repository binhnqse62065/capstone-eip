CREATE TABLE [dbo].[BlogCategory] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [FeedburnerUrl]   NVARCHAR (MAX) NULL,
    [PageTitle]       NVARCHAR (MAX) NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    [UrlHandle]       NVARCHAR (MAX) NULL,
    [IsAllowComment]  NVARCHAR (MAX) NOT NULL,
    [StoreId]         INT            NOT NULL,
    [IsActive]        BIT            NOT NULL,
    [Feedburner]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BlogCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogCategory_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

