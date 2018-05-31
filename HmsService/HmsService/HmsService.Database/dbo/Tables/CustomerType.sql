CREATE TABLE [dbo].[CustomerType] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [CustomerType] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

