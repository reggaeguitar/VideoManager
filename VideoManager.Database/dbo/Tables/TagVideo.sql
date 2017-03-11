CREATE TABLE [dbo].[TagVideo] (
    [TagId]   INT NOT NULL,
    [VideoId] INT NOT NULL,
    CONSTRAINT [TagVideo_pk] PRIMARY KEY CLUSTERED ([TagId] ASC, [VideoId] ASC),
    CONSTRAINT [fk_TagVideo_Tag] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([TagId]),
    CONSTRAINT [fk_TagVideo_Video] FOREIGN KEY ([VideoId]) REFERENCES [dbo].[Video] ([VideoId])
);

