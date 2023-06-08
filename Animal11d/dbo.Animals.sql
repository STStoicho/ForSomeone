CREATE TABLE [dbo].[Animals] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Age]         INT            NOT NULL,
    [BreedsId]    INT            NOT NULL,
    [RegisterOn]  DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NULL,
    CONSTRAINT [PK_dbo.Animals] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Animals_dbo.Breeds_BreedsId] FOREIGN KEY ([BreedsId]) REFERENCES [dbo].[Breeds] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BreedsId]
    ON [dbo].[Animals]([BreedsId] ASC);

