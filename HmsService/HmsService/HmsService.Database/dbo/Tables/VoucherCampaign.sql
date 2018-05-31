CREATE TABLE [dbo].[VoucherCampaign] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [StartDate]   DATETIME       NULL,
    [EndDate]     DATETIME       NULL,
    [Status]      INT            NOT NULL,
    [Price]       DECIMAL (18)   NOT NULL,
    [Value]       DECIMAL (18)   NOT NULL,
    [ProviderId]  INT            NULL,
    [IsActive]    BIT            NOT NULL,
    CONSTRAINT [PK_VoucherCampagin] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VoucherCampagin_VourcherProvider] FOREIGN KEY ([ProviderId]) REFERENCES [dbo].[VoucherProvider] ([Id])
);

