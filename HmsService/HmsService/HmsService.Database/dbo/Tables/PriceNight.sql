CREATE TABLE [dbo].[PriceNight] (
    [RoomPriceID]  INT      IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [PriceGroupID] INT      NOT NULL,
    [StartTime]    DATETIME NOT NULL,
    [EndTime]      DATETIME NOT NULL,
    [Price]        INT      NOT NULL,
    [MaxDuration]  INT      NOT NULL,
    [CheckTime]    DATETIME NOT NULL,
    [PricePerHour] INT      NOT NULL,
    CONSTRAINT [PK__NightPrice__4865BE2A] PRIMARY KEY CLUSTERED ([RoomPriceID] ASC),
    CONSTRAINT [FK_PriceNight_PriceGroup] FOREIGN KEY ([PriceGroupID]) REFERENCES [dbo].[PriceGroup] ([PriceGroupID])
);

