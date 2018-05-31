CREATE TABLE [dbo].[TotalBooking] (
    [SourceID]   INT  NOT NULL,
    [RoomTypeID] INT  NOT NULL,
    [Day]        DATE NOT NULL,
    [QuotaInUse] INT  NOT NULL,
    CONSTRAINT [PK_TotalBooking] PRIMARY KEY CLUSTERED ([SourceID] ASC, [RoomTypeID] ASC, [Day] ASC)
);

