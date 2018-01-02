CREATE TABLE [dbo].[Project]
(
	[ProjectID] INT NOT NULL PRIMARY KEY, 
    [DesignNo] CHAR(12) NULL, 
    [ProjectName] NVARCHAR(50) NULL, 
    [Company] NVARCHAR(50) NULL, 
    [Leader] NVARCHAR(10) NULL
)
