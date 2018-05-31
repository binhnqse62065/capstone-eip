CREATE TABLE [dbo].[Guest] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (500) NOT NULL,
    [PersonId]  NVARCHAR (20)  NOT NULL,
    [BirthYear] INT            NULL,
    [Phone]     NVARCHAR (20)  NULL,
    [Address]   NVARCHAR (MAX) NULL,
    [Sex]       BIT            NULL,
    [RentId]    INT            NULL,
    [RentGroup] INT            NULL,
    [Note]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Guest_Rent] FOREIGN KEY ([RentId]) REFERENCES [dbo].[Rent] ([RentID]),
    CONSTRAINT [FK_Guest_RentGroup] FOREIGN KEY ([RentGroup]) REFERENCES [dbo].[RentGroup] ([Id])
);

