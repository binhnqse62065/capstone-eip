CREATE TABLE [dbo].[PriceAddition] (
    [AdditionPriceID] INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [EarlyHourRange]  VARCHAR (100) NOT NULL,
    [EarlyPriceRange] VARCHAR (100) NOT NULL,
    [LateHourRange]   VARCHAR (100) NOT NULL,
    [LatePriceRange]  VARCHAR (100) NOT NULL,
    [Name]            NVARCHAR (50) NULL,
    CONSTRAINT [PK_AdditionPrice] PRIMARY KEY CLUSTERED ([AdditionPriceID] ASC)
);

