CREATE TABLE [dbo].[RentGroup] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [Code]        NVARCHAR (50)  NULL,
    [CustomerID]  INT            NULL,
    [SourceID]    INT            NOT NULL,
    [BookingDate] DATETIME       NOT NULL,
    [GetRoomDate] DATETIME       NULL,
    [Note]        NVARCHAR (MAX) NULL,
    [StoreID]     INT            NULL,
    CONSTRAINT [PK_BookingGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RentGroup_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

