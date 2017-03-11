CREATE TABLE [dbo].[Tag] (
    [TagId]   INT            IDENTITY (1, 1) NOT NULL,
    [TagName] NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([TagId] ASC)
);

