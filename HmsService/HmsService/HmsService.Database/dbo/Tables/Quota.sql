CREATE TABLE [dbo].[Quota] (
    [QuotaID]    INT      IDENTITY (1, 1) NOT NULL,
    [SourceID]   INT      NOT NULL,
    [RoomTypeID] INT      NOT NULL,
    [FromDate]   DATETIME NOT NULL,
    [ToDate]     DATETIME NOT NULL,
    [Quantity]   INT      NOT NULL,
    [Price]      INT      NOT NULL,
    CONSTRAINT [PK_Quota] PRIMARY KEY CLUSTERED ([QuotaID] ASC),
    CONSTRAINT [FK_Quota_BookingSource] FOREIGN KEY ([SourceID]) REFERENCES [dbo].[BookingSource] ([SourceID]),
    CONSTRAINT [FK_Quota_RoomCategory] FOREIGN KEY ([RoomTypeID]) REFERENCES [dbo].[RoomCategory] ([CategoryID])
);

