CREATE TABLE [dbo].[Article] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [StoreId]     INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Decription]  NVARCHAR (MAX) NOT NULL,
    [ContentHTML] NVARCHAR (MAX) NOT NULL,
    [DateCreate]  DATE           NOT NULL,
    [IsAvailable] BIT            NOT NULL,
    [Thumbnail]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Article_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([ID])
);

