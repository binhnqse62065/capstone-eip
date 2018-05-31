CREATE TABLE [dbo].[SessionDivision] (
    [DivisionID]    INT            IDENTITY (1, 1) NOT NULL,
    [SessionID]     INT            NOT NULL,
    [StaffUsername] NVARCHAR (256) NOT NULL,
    [StartTime]     DATETIME       NULL,
    [EndTime]       DATETIME       NULL,
    CONSTRAINT [PK_SectionDivision] PRIMARY KEY CLUSTERED ([DivisionID] ASC),
    CONSTRAINT [CHK_SectionDivision_Time] CHECK ([StartTime] IS NULL OR [EndTime] IS NULL OR [StartTime]<[EndTime]),
    CONSTRAINT [FK_SectionDivision_Section] FOREIGN KEY ([SessionID]) REFERENCES [dbo].[Session] ([SessionID]),
    CONSTRAINT [UK_SectionDivision] UNIQUE NONCLUSTERED ([SessionID] ASC, [StaffUsername] ASC)
);

