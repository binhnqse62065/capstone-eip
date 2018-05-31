CREATE TABLE [dbo].[VoucherProvider] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [ProviderName] NVARCHAR (50) NOT NULL,
    [IsActive]     BIT           NOT NULL,
    CONSTRAINT [PK_VourcherProvider] PRIMARY KEY CLUSTERED ([Id] ASC)
);

