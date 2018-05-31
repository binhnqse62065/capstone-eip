CREATE TABLE [dbo].[Rent] (
    [RentID]                    INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceID]                 NVARCHAR (50)  NULL,
    [CheckInDate]               DATETIME       NULL,
    [CheckOutDate]              DATETIME       NULL,
    [ApproveDate]               DATETIME       NULL,
    [TotalAmount]               INT            NOT NULL,
    [Discount]                  INT            NOT NULL,
    [DiscountOrderDetail]       INT            NOT NULL,
    [FinalAmount]               INT            NOT NULL,
    [OrderStatus]               INT            NOT NULL,
    [RentStatus]                INT            NULL,
    [OrderType]                 INT            NOT NULL,
    [RentType]                  INT            NOT NULL,
    [Notes]                     NVARCHAR (250) NULL,
    [FeeDescription]            NVARCHAR (250) NULL,
    [CheckInPerson]             NVARCHAR (50)  NULL,
    [CheckOutPerson]            NVARCHAR (50)  NULL,
    [ApprovePerson]             NVARCHAR (50)  NULL,
    [PriceGroupID]              INT            NULL,
    [BookingDate]               DATETIME       NULL,
    [ArrivalDate]               DATETIME       NULL,
    [DepartureDate]             DATETIME       NULL,
    [CustomerID]                INT            NULL,
    [SubRentGroupID]            INT            NULL,
    [RoomId]                    INT            CONSTRAINT [DF_Rent_RoomId] DEFAULT ((5)) NULL,
    [IsFixedPrice]              BIT            CONSTRAINT [DF_Rent_IsFixedPrice] DEFAULT ((0)) NOT NULL,
    [LastRecordDate]            DATETIME       NULL,
    [ServedPerson]              NVARCHAR (50)  NULL,
    [StoreID]                   INT            NULL,
    [SourceID]                  INT            NULL,
    [SourceType]                INT            CONSTRAINT [DF_Rent_SourceID] DEFAULT ((0)) NOT NULL,
    [DeliveryAddress]           NVARCHAR (500) NULL,
    [DeliveryStatus]            INT            NULL,
    [OrderDetailsTotalQuantity] AS             ([dbo].[CalculateRentTotalQuantity]([RentID])),
    [CheckinHour]               AS             (datepart(hour,[CheckInDate])) PERSISTED,
    [TotalInvoicePrint]         INT            NULL,
    [VAT]                       INT            NULL,
    [VATAmount]                 INT            NULL,
    [NumberOfGuest]             INT            NULL,
    CONSTRAINT [PK__Rent__7908F585] PRIMARY KEY CLUSTERED ([RentID] ASC),
    CONSTRAINT [FK_Rent_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_Rent_PriceGroup] FOREIGN KEY ([PriceGroupID]) REFERENCES [dbo].[PriceGroup] ([PriceGroupID]),
    CONSTRAINT [FK_Rent_Room1] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([RoomID]),
    CONSTRAINT [FK_Rent_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID]),
    CONSTRAINT [FK_Rent_SubRentGroup] FOREIGN KEY ([SubRentGroupID]) REFERENCES [dbo].[SubRentGroup] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Rent_CheckInDate]
    ON [dbo].[Rent]([CheckInDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Rent_CheckinHour]
    ON [dbo].[Rent]([CheckinHour] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The last time transfer rent to journal.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rent', @level2type = N'COLUMN', @level2name = N'LastRecordDate';

