CREATE TABLE [dbo].[Voucher] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [CampaginId]   INT           NULL,
    [SerialNumber] NVARCHAR (50) NOT NULL,
    [Status]       INT           NOT NULL,
    [IsActive]     BIT           NOT NULL,
    [StoreId]      INT           NULL,
    [StoreName]    NVARCHAR (50) NULL,
    [DateUse]      DATETIME      NULL,
    CONSTRAINT [PK_Vourcher] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vourcher_VoucherCampagin] FOREIGN KEY ([CampaginId]) REFERENCES [dbo].[VoucherCampaign] ([Id])
);

