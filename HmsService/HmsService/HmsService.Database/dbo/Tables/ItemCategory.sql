CREATE TABLE [dbo].[ItemCategory] (
    [CateID]      INT           IDENTITY (1, 1) NOT NULL,
    [CateName]    NVARCHAR (50) NOT NULL,
    [Type]        INT           NOT NULL,
    [IsDisplayed] BIT           NOT NULL,
    CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED ([CateID] ASC)
);

