CREATE TABLE [dbo].[InventoryChecking] (
    [CheckingId]   INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [StoreId]      INT            NOT NULL,
    [CheckingDate] DATETIME       NOT NULL,
    [Creator]      NVARCHAR (250) NOT NULL,
    [Status]       INT            NOT NULL,
    CONSTRAINT [PK__Inventor__4D7B4ADD145C0A3F] PRIMARY KEY CLUSTERED ([CheckingId] ASC)
);

