CREATE TABLE [dbo].[Store] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Address]      NVARCHAR (150) NOT NULL,
    [Lat]          NVARCHAR (256) NULL,
    [Lon]          NVARCHAR (50)  NULL,
    [isAvailable]  BIT            NULL,
    [Email]        NVARCHAR (50)  NULL,
    [Phone]        NVARCHAR (50)  NULL,
    [Fax]          NVARCHAR (50)  NULL,
    [CreateDate]   DATETIME       NULL,
    [Type]         INT            CONSTRAINT [DF_Store_Type] DEFAULT ((0)) NOT NULL,
    [RoomRentMode] INT            NULL,
    [ReportDate]   DATETIME       NULL,
    [ShortName]    NVARCHAR (100) NULL,
    [GroupId]      INT            NULL,
    [OpenTime]     DATETIME       NULL,
    [CloseTime]    DATETIME       NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Store_Group] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Group] ([GroupId])
);

