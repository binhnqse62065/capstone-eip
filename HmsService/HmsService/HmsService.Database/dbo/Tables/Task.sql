CREATE TABLE [dbo].[Task] (
    [TaskID]         INT            IDENTITY (1, 1) NOT NULL,
    [RoomID]         NVARCHAR (50)  NOT NULL,
    [TaskDesciption] NVARCHAR (250) NOT NULL,
    [ExecuteDate]    DATETIME       NOT NULL,
    [CreateDate]     DATETIME       NOT NULL,
    [IsDone]         BIT            NOT NULL,
    [AssignTo]       NVARCHAR (MAX) NOT NULL,
    [StoreID]        INT            NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskID] ASC)
);

