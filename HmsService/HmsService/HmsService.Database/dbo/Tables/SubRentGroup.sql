CREATE TABLE [dbo].[SubRentGroup] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NULL,
    [RoomType]         INT           NOT NULL,
    [FromDate]         DATETIME      NOT NULL,
    [ToDate]           DATETIME      NOT NULL,
    [Quantity]         INT           CONSTRAINT [DF_SubRentGroup_Quantity] DEFAULT ((0)) NOT NULL,
    [ServicedQuantity] INT           CONSTRAINT [DF_SubRentGroup_ServicedQuantity] DEFAULT ((0)) NULL,
    [RentGroupID]      INT           NOT NULL,
    [Status]           INT           CONSTRAINT [DF_SubRentGroup_Status] DEFAULT ((-1)) NULL,
    [SourceId]         INT           CONSTRAINT [DF_SubRentGroup_SourceId] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_SubRentGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SubRentGroup_RentGroup] FOREIGN KEY ([RentGroupID]) REFERENCES [dbo].[RentGroup] ([Id]),
    CONSTRAINT [FK_SubRentGroup_RoomCategory] FOREIGN KEY ([RoomType]) REFERENCES [dbo].[RoomCategory] ([CategoryID])
);

