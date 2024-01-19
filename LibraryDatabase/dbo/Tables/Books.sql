CREATE TABLE [dbo].[Books] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [Naslov]          NVARCHAR (50) NOT NULL,
    [AvtorID]         INT           NOT NULL,
    [Izdavacka kukja] NVARCHAR (50) NULL,
    [Godina]          INT           NULL,
    [ISBN]            INT           NULL,
    [KategorijaID]    INT           NOT NULL,
    [Jazik]           NVARCHAR (50) NULL,
    [Status]          NVARCHAR (50) NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Books_Avtor] FOREIGN KEY ([AvtorID]) REFERENCES [dbo].[Avtor] ([ID]),
    CONSTRAINT [FK_Books_Kategorija] FOREIGN KEY ([KategorijaID]) REFERENCES [dbo].[Kategorija] ([ID])
);

