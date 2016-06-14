CREATE TABLE [dbo].[tbDemo] (
    [ID]   NVARCHAR (5)   NOT NULL,
    [Code] INT            NOT NULL,
    [Name] NVARCHAR (256) NULL,
    [Note] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_tbDemo] PRIMARY KEY CLUSTERED ([ID] ASC, [Code] ASC)
);

