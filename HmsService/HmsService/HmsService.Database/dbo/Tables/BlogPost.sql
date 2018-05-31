CREATE TABLE [dbo].[BlogPost] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [BlogContent]     NVARCHAR (MAX) NULL,
    [Excerpt]         NVARCHAR (MAX) NULL,
    [BlogCategoryId]  INT            NULL,
    [PageTitle]       NVARCHAR (MAX) NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    [Active]          BIT            NOT NULL,
    [StoreId]         INT            NOT NULL,
    [Image]           NVARCHAR (MAX) NULL,
    [Author]          NVARCHAR (MAX) NULL,
    [UrlHandle]       NVARCHAR (MAX) NULL,
    [CreatedTime]     DATETIME       NOT NULL,
    [UpdatedTime]     DATETIME       NOT NULL,
    CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogPost_BlogCategory] FOREIGN KEY ([BlogCategoryId]) REFERENCES [dbo].[BlogCategory] ([Id]),
    CONSTRAINT [FK_BlogPost_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

