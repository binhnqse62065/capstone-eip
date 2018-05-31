CREATE TABLE [dbo].[Menu] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [MenuText]     NVARCHAR (250) NULL,
    [MenuText1]    NVARCHAR (250) NULL,
    [MenuText2]    NVARCHAR (250) NULL,
    [Link]         NVARCHAR (250) NULL,
    [IconUrl]      NVARCHAR (250) NULL,
    [DisplayOrder] INT            NOT NULL,
    [ParentMenuId] INT            NULL,
    [MenuLevel]    INT            NOT NULL,
    [StoreFilter]  INT            NOT NULL,
    [Status]       BIT            NOT NULL,
    [IsSystemMenu] BIT            NOT NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Menu_Menu] FOREIGN KEY ([ParentMenuId]) REFERENCES [dbo].[Menu] ([Id])
);

