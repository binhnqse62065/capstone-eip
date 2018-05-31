CREATE TABLE [dbo].[ReportTracking] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [StoreId]      INT           NOT NULL,
    [Date]         DATETIME      NULL,
    [DateUpdate]   DATETIME      NULL,
    [UpdatePerson] NVARCHAR (50) NULL,
    [IsUpdate]     BIT           NULL,
    CONSTRAINT [PK_ReportTracking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ReportTracking_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

