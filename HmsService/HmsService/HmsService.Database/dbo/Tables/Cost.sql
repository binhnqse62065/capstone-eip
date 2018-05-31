CREATE TABLE [dbo].[Cost] (
    [CostID]          INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CatID]           INT            NOT NULL,
    [CostDescription] NVARCHAR (200) NOT NULL,
    [CostDate]        DATETIME       NOT NULL,
    [Amount]          INT            NOT NULL,
    [CostStatus]      INT            NOT NULL,
    [PaidPerson]      NVARCHAR (50)  NULL,
    [LoggedPerson]    NVARCHAR (50)  NOT NULL,
    [ApprovedPerson]  NVARCHAR (50)  NULL,
    [StoreId]         INT            NULL,
    CONSTRAINT [PK_Cost] PRIMARY KEY CLUSTERED ([CostID] ASC),
    CONSTRAINT [FK_Cost_CostCategory] FOREIGN KEY ([CatID]) REFERENCES [dbo].[CostCategory] ([CatID])
);

