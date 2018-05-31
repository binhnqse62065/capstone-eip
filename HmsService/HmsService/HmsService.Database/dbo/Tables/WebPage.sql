CREATE TABLE [dbo].[WebPage] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [PageContent]     NVARCHAR (MAX) NULL,
    [PageTitle]       NVARCHAR (MAX) NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    [UrlHandle]       NVARCHAR (MAX) NULL,
    [IsActive]        BIT            NOT NULL,
    [StoreId]         INT            NULL,
    CONSTRAINT [PK_WebPage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WebPage_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

