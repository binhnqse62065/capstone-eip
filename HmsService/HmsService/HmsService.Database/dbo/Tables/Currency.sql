CREATE TABLE [dbo].[Currency] (
    [Code]         CHAR (5)      NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [ExchangeRate] FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([Code] ASC)
);

