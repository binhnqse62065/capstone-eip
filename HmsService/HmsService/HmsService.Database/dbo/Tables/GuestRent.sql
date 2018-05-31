CREATE TABLE [dbo].[GuestRent] (
    [GuestId] INT NOT NULL,
    [RentId]  INT NOT NULL,
    CONSTRAINT [PK_GuestRent] PRIMARY KEY CLUSTERED ([GuestId] ASC, [RentId] ASC),
    CONSTRAINT [FK_GuestRent_Guest] FOREIGN KEY ([GuestId]) REFERENCES [dbo].[Guest] ([Id]),
    CONSTRAINT [FK_GuestRent_Rent] FOREIGN KEY ([RentId]) REFERENCES [dbo].[Rent] ([RentID])
);

