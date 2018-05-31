CREATE TABLE [dbo].[Profiles] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [PropertyNames]        NVARCHAR (4000)  NOT NULL,
    [PropertyValueStrings] NVARCHAR (4000)  NOT NULL,
    [PropertyValueBinary]  IMAGE            NOT NULL,
    [LastUpdatedDate]      DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [UserProfile] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

