CREATE TABLE [dbo].[DateHotelReport] (
    [Id]                INT            NOT NULL,
    [Date]              DATETIME       NOT NULL,
    [CreateBy]          NVARCHAR (MAX) NULL,
    [Status]            INT            NOT NULL,
    [StoreID]           INT            NOT NULL,
    [TotalAmount]       INT            NOT NULL,
    [Discount]          INT            NOT NULL,
    [FinalAmount]       INT            NOT NULL,
    [TotalOrderDetail]  INT            NOT NULL,
    [TotalOrderFeeItem] INT            NOT NULL,
    CONSTRAINT [PK_DateHotelReport] PRIMARY KEY CLUSTERED ([Id] ASC)
);

