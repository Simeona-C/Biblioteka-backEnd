CREATE TABLE [dbo].[Avtor] (
    [ID]                 INT           IDENTITY (1, 1) NOT NULL,
    [Ime]                NVARCHAR (50) NOT NULL,
    [Prezime]            NVARCHAR (50) NOT NULL,
    [Godina na ragjanje] INT           NULL,
    [Zemja]              NVARCHAR (50) NULL,
    CONSTRAINT [PK_Avtor] PRIMARY KEY CLUSTERED ([ID] ASC)
);

