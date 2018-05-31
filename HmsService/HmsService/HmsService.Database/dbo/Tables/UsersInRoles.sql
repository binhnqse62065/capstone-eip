CREATE TABLE [dbo].[UsersInRoles] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [UsersInRoleRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]),
    CONSTRAINT [UsersInRoleUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

