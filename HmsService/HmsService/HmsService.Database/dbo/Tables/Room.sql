CREATE TABLE [dbo].[Room] (
    [RoomID]          INT            IDENTITY (1, 1) NOT NULL,
    [RoomName]        NVARCHAR (50)  NULL,
    [RoomDescription] NVARCHAR (250) NULL,
    [RoomStatus]      INT            NOT NULL,
    [FloorID]         INT            NOT NULL,
    [CategoryID]      INT            NOT NULL,
    [IsDeleted]       BIT            CONSTRAINT [DF_Room_IsDeleted] DEFAULT ((0)) NOT NULL,
    [StoreID]         INT            NULL,
    [CurrentRentId]   INT            NULL,
    [RentStatus]      INT            NULL,
    [PosX]            INT            NOT NULL,
    [PosSpanX]        INT            NOT NULL,
    [PosY]            INT            NOT NULL,
    [PosSpanY]        INT            NOT NULL,
    [RentType]        INT            NULL,
    CONSTRAINT [PK__Room__43A1090D] PRIMARY KEY CLUSTERED ([RoomID] ASC),
    CONSTRAINT [FK__Room__CategoryID__76EBA2E9] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[RoomCategory] ([CategoryID]),
    CONSTRAINT [FK__Room__FloorID__4589517F] FOREIGN KEY ([FloorID]) REFERENCES [dbo].[RoomFloor] ([FloorID])
);

