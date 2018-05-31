CREATE TABLE [dbo].[HotelInfo] (
    [HotelID]      INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [HotelName]    NVARCHAR (250) NOT NULL,
    [Address]      NVARCHAR (250) NOT NULL,
    [Phone]        NVARCHAR (250) NOT NULL,
    [Fax]          NVARCHAR (250) NOT NULL,
    [Email]        NVARCHAR (250) NOT NULL,
    [Website]      NVARCHAR (250) NOT NULL,
    [City]         NVARCHAR (250) NOT NULL,
    [Descriptions] NVARCHAR (250) NOT NULL,
    [StartDayTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_HotelInfo] PRIMARY KEY CLUSTERED ([HotelID] ASC)
);

