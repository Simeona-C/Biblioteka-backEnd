CREATE TABLE [dbo].[Members] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [Ime]             NVARCHAR (50) NOT NULL,
    [Prezime]         NVARCHAR (50) NOT NULL,
    [Telefonski broj] INT           NOT NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED ([ID] ASC)
);

