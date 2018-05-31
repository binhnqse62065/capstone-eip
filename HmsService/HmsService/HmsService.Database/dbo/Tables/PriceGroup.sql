CREATE TABLE [dbo].[PriceGroup] (
    [PriceGroupID]         INT           IDENTITY (1, 1) NOT NULL,
    [PriceGroupName]       NVARCHAR (50) NOT NULL,
    [DayPrice]             INT           NOT NULL,
    [RoundMinute]          INT           NOT NULL,
    [FirstHourPrice]       INT           NOT NULL,
    [SecondHourPrice]      INT           NOT NULL,
    [ThirdHourPrice]       INT           NOT NULL,
    [NextHourPrice]        INT           NOT NULL,
    [NightAdditionPriceID] INT           NOT NULL,
    [IsAvailable]          BIT           NOT NULL,
    [AdditionPrice]        INT           NOT NULL,
    [DayLimitTime1]        INT           NOT NULL,
    [DayPriceLimitTime1]   INT           NOT NULL,
    [DayLimitTime2]        INT           NOT NULL,
    [DayPriceLimitTime2]   INT           NOT NULL,
    CONSTRAINT [PK__Price__4B422AD5] PRIMARY KEY CLUSTERED ([PriceGroupID] ASC)
);

