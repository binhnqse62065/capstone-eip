CREATE TABLE [dbo].[Payment] (
    [PaymentID]    INT            IDENTITY (1, 1) NOT NULL,
    [ToRentID]     INT            NULL,
    [Amount]       INT            NOT NULL,
    [CurrencyCode] CHAR (5)       NULL,
    [FCAmount]     MONEY          NOT NULL,
    [Notes]        NVARCHAR (250) NULL,
    [PayTime]      DATETIME       NOT NULL,
    [Status]       INT            NOT NULL,
    [Type]         INT            CONSTRAINT [DF_Payment_Type] DEFAULT ((0)) NOT NULL,
    [RealAmount]   INT            NULL,
    CONSTRAINT [PK__Payment__9B556A585AEE82B9] PRIMARY KEY CLUSTERED ([PaymentID] ASC),
    CONSTRAINT [FK__Payment__RentID__7EC1CEDB] FOREIGN KEY ([ToRentID]) REFERENCES [dbo].[Rent] ([RentID]) ON DELETE CASCADE
);

