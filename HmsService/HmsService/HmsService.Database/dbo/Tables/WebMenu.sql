CREATE TABLE [dbo].[WebMenu] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [MenuText]     NVARCHAR (MAX) NULL,
    [MenuText1]    NVARCHAR (MAX) NULL,
    [MenuText2]    NVARCHAR (MAX) NULL,
    [Type]         NVARCHAR (MAX) NULL,
    [Link]         NVARCHAR (MAX) NULL,
    [IconUrl]      NVARCHAR (MAX) NULL,
    [DisplayOrder] INT            NOT NULL,
    [ParentMenuId] INT            NULL,
    [MenuLevel]    INT            CONSTRAINT [DF_WebMenu_MenuLevel] DEFAULT ((0)) NULL,
    [StoreFilter]  INT            NULL,
    [Active]       BIT            CONSTRAINT [DF_WebMenu_Status] DEFAULT ((1)) NOT NULL,
    [IsSystemMenu] BIT            NOT NULL,
    [CategoryId]   INT            NOT NULL,
    CONSTRAINT [PK_WebMenu] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WebMenu_WebMenu] FOREIGN KEY ([ParentMenuId]) REFERENCES [dbo].[WebMenu] ([Id]),
    CONSTRAINT [FK_WebMenu_WebMenuCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[WebMenuCategory] ([Id])
);

