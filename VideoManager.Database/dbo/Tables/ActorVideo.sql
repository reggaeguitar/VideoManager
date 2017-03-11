CREATE TABLE [dbo].[ActorVideo] (
    [ActorId] INT NOT NULL,
    [VideoId] INT NOT NULL,
    CONSTRAINT [ActorVideo_pk] PRIMARY KEY CLUSTERED ([ActorId] ASC, [VideoId] ASC),
    CONSTRAINT [fk_ActorVideo_Actor] FOREIGN KEY ([ActorId]) REFERENCES [dbo].[Actor] ([ActorId]),
    CONSTRAINT [fk_ActorVideo_Video] FOREIGN KEY ([VideoId]) REFERENCES [dbo].[Video] ([VideoId])
);

