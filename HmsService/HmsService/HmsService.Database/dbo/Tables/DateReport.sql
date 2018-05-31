CREATE TABLE [dbo].[DateReport] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [Date]                DATETIME       NOT NULL,
    [CreateBy]            NVARCHAR (256) NULL,
    [Status]              INT            CONSTRAINT [DF_DateReport_Status1] DEFAULT ((0)) NOT NULL,
    [StoreID]             INT            NOT NULL,
    [TotalAmount]         INT            NOT NULL,
    [FinalAmount]         INT            NOT NULL,
    [Discount]            INT            NOT NULL,
    [DiscountOrderDetail] INT            NOT NULL,
    [TotalCash]           INT            CONSTRAINT [DF_DateReport_TotalCash] DEFAULT ((0)) NOT NULL,
    [TotalOrder]          INT            NOT NULL,
    [TotalOrderAtStore]   INT            NOT NULL,
    [TotalOrderTakeAway]  INT            NOT NULL,
    [TotalOrderDelivery]  INT            NOT NULL,
    [TotalOrderDetail]    INT            NOT NULL,
    [TotalOrderFeeItem]   INT            NOT NULL,
    CONSTRAINT [PK_DateReport] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_DateReport_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID])
);

