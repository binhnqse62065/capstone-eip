CREATE TABLE [dbo].[Session] (
    [SessionID]    INT            IDENTITY (1, 1) NOT NULL,
    [StartTime]    DATETIME       NOT NULL,
    [EndTime]      DATETIME       NULL,
    [CreateBy]     NVARCHAR (256) NOT NULL,
    [Status]       INT            CONSTRAINT [DF_Session_Status] DEFAULT ((0)) NOT NULL,
    [StoreID]      INT            NOT NULL,
    [FloatMoney]   MONEY          CONSTRAINT [DF_Session_FloatMoney] DEFAULT ((0)) NOT NULL,
    [TotalAmount]  MONEY          NOT NULL,
    [FinalAmount]  MONEY          NOT NULL,
    [TotalCash]    MONEY          CONSTRAINT [DF_Session_TotalCash] DEFAULT ((0)) NOT NULL,
    [RealCash]     MONEY          CONSTRAINT [DF_Session_RealCash] DEFAULT ((0)) NOT NULL,
    [PreSessionId] INT            NOT NULL,
    CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED ([SessionID] ASC),
    CONSTRAINT [CHK_SectionTime] CHECK ([StartTime]<[EndTime]),
    CONSTRAINT [FK_Session_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID])
);

