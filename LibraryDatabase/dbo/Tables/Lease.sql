CREATE TABLE [dbo].[Lease] (
    [ID]           INT  IDENTITY (1, 1) NOT NULL,
    [BookID]       INT  NOT NULL,
    [MemberID]     INT  NOT NULL,
    [DateLeased]   DATE NOT NULL,
    [DateReturned] DATE NULL,
    CONSTRAINT [PK_Lease] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Lease_Books] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Books] ([ID]),
    CONSTRAINT [FK_Lease_Members] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Members] ([ID])
);

