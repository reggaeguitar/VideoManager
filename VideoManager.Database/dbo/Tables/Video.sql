CREATE TABLE [dbo].[Video] (
    [VideoId]     INT            IDENTITY (1, 1) NOT NULL,
    [DateAdded]   DATETIME       NOT NULL,
    [LastVisited] DATETIME       NULL,
    [Points]      INT            NOT NULL,
    [Title]       NVARCHAR (300) NOT NULL,
    [Url]         NVARCHAR (300) NOT NULL,
    [VisitCount]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([VideoId] ASC)
);

