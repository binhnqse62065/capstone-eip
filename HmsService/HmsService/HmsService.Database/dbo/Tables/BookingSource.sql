CREATE TABLE [dbo].[BookingSource] (
    [SourceID]   INT            IDENTITY (1, 1) NOT NULL,
    [SourceName] NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_BookingSource] PRIMARY KEY CLUSTERED ([SourceID] ASC)
);

