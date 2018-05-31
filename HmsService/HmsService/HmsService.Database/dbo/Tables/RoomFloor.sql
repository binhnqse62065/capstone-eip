CREATE TABLE [dbo].[RoomFloor] (
    [FloorID]   INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [FloorName] NVARCHAR (50) NOT NULL,
    [Position]  INT           NULL,
    [StoreId]   INT           NOT NULL,
    [IsDelete]  BIT           NULL,
    CONSTRAINT [PK__RoomFloo__49D1E86B2B3F6F97] PRIMARY KEY CLUSTERED ([FloorID] ASC)
);

