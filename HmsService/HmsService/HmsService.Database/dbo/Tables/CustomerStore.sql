CREATE TABLE [dbo].[CustomerStore] (
    [ID]            INT        IDENTITY (1, 1) NOT NULL,
    [CustomerID]    INT        NOT NULL,
    [StoreID]       INT        NOT NULL,
    [TotalOrder]    INT        NULL,
    [TotalAmount]   FLOAT (53) NULL,
    [AverageAmount] FLOAT (53) NULL,
    [VisitAmount]   INT        NULL,
    [DateAmount]    INT        NULL,
    [Frequency]     FLOAT (53) NULL,
    [LastVisitDate] DATETIME   NOT NULL,
    [UpdateDate]    DATETIME   NOT NULL,
    CONSTRAINT [PK_CustomerStore] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CustomerStore_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_CustomerStore_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID])
);

