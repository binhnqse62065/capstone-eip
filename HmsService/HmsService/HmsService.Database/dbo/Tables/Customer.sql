CREATE TABLE [dbo].[Customer] (
    [CustomerID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (250) NULL,
    [Address]             NVARCHAR (250) NULL,
    [Phone]               NVARCHAR (250) NULL,
    [Fax]                 NVARCHAR (250) NULL,
    [ContactPerson]       NVARCHAR (250) NULL,
    [ContactPersonNumber] NVARCHAR (50)  NULL,
    [Website]             NVARCHAR (100) NULL,
    [Email]               NCHAR (250)    NULL,
    [Type]                INT            NOT NULL,
    [AccountID]           INT            NULL,
    [IDCard]              VARCHAR (15)   NULL,
    [Gender]              BIT            NULL,
    [BirthDay]            DATE           NULL,
    [StoreRegisterId]     INT            NULL,
    [District]            NVARCHAR (100) NULL,
    [City]                NVARCHAR (50)  NULL,
    [CustomerCode]        VARCHAR (20)   NULL,
    [MembershipCard]      NCHAR (30)     NULL,
    CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED ([CustomerID] ASC),
    CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY ([Type]) REFERENCES [dbo].[CustomerType] ([ID])
);

