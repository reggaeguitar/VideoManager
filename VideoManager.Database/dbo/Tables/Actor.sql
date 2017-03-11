CREATE TABLE [dbo].[Actor] (
    [ActorId]   INT            IDENTITY (1, 1) NOT NULL,
    [ActorName] NVARCHAR (300) NULL,
    PRIMARY KEY CLUSTERED ([ActorId] ASC)
);

