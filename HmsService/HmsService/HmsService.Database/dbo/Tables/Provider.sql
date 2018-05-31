CREATE TABLE [dbo].[Provider] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [ProviderName] NVARCHAR (50)  NULL,
    [IsAvailable]  BIT            NULL,
    [Address]      NVARCHAR (MAX) NULL,
    [Phone]        INT            NULL,
    [Email]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED ([Id] ASC)
);

