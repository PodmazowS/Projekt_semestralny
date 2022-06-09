CREATE TABLE [dbo].[Table2] (
    [Id]          INT        IDENTITY (1, 1) NOT NULL,
    [FirstName]   NCHAR (50) NULL,
    [SecondName]  NCHAR (50) NULL,
    [Number]      NCHAR (50) NULL,
    [Email]       NCHAR (50) NULL,
    [Card_number] NCHAR (50) NULL,
    [Room_type]   NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
