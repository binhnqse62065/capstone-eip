CREATE TABLE [dbo].[Transaction] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]             INT            NOT NULL,
    [Amount]                MONEY          NOT NULL,
    [CurrencyCode]          CHAR (5)       NOT NULL,
    [FCAmount]              MONEY          NOT NULL,
    [Date]                  DATETIME       NOT NULL,
    [Notes]                 NVARCHAR (255) NULL,
    [IsIncreaseTransaction] BIT            CONSTRAINT [DF__Transacti__IsInc__18178C8A] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK__Transact__3214EC07162F4418] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountID])
);

