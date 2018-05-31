CREATE TABLE [dbo].[Group] (
    [GroupId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NULL,
    [Description] NVARCHAR (50) NULL,
    [IsDisplayed] BIT           NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED ([GroupId] ASC)
);

