CREATE TABLE [dbo].[Kategorija] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Opis] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED ([ID] ASC)
);

