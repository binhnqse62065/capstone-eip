CREATE TABLE [dbo].[MenuRole] (
    [MenuId] INT            NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_MenuRole] PRIMARY KEY CLUSTERED ([MenuId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_MenuRole_AspNetRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]),
    CONSTRAINT [FK_MenuRole_Menu] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menu] ([Id])
);

