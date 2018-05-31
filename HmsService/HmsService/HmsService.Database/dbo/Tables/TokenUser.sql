CREATE TABLE [dbo].[TokenUser] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Username]   NVARCHAR (256) NULL,
    [Token]      NVARCHAR (MAX) NULL,
    [CreateTime] DATETIME       NULL,
    [EndTime]    DATETIME       NULL,
    CONSTRAINT [PK_TokenUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

