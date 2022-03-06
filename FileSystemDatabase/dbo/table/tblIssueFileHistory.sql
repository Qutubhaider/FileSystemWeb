CREATE TABLE [dbo].[tblIssueFileHistory]
(
    inlssueFileId INT IDENTITY(1,1) PRIMARY KEY,
    unlssueFileId UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    inAssignUserId INT,
    inDivisionId INT,
    inDepartmentId INT,
    inStoreFileDetailsId INT,
    dtIssueDate INT,
    inStatus INT,
    flgIsDeleted BIT DEFAULT(0),
    dtCreateDate DATETIME NOT NULL,
    inCreatedBy INT NOT NULL
)