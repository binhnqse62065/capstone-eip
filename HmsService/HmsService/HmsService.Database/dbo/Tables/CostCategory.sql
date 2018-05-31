﻿CREATE TABLE [dbo].[CostCategory] (
    [CatID]   INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [CatName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CostCategory] PRIMARY KEY CLUSTERED ([CatID] ASC)
);

