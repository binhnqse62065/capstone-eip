CREATE TABLE [dbo].[SessionProduct] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [SessionID]       INT           NOT NULL,
    [ProductName]     NVARCHAR (50) NULL,
    [ProductID]       INT           NOT NULL,
    [Quantity]        INT           NOT NULL,
    [TotalPrice]      FLOAT (53)    NOT NULL,
    [DiscountPercent] INT           NULL,
    [DiscountPrice]   FLOAT (53)    NULL,
    CONSTRAINT [PK_SessionProduct] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SessionProduct_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]),
    CONSTRAINT [FK_SessionProduct_Session] FOREIGN KEY ([SessionID]) REFERENCES [dbo].[Session] ([SessionID])
);

