CREATE TABLE [dbo].[StoreDomain] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [StoreId]  INT            NOT NULL,
    [Protocol] VARCHAR (10)   NOT NULL,
    [HostName] NVARCHAR (256) NOT NULL,
    [Port]     INT            NOT NULL,
    [Active]   BIT            NOT NULL,
    CONSTRAINT [PK_StoreDomain] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StoreDomain_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

