CREATE TABLE tblCategoryMaster
(
    inCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    unCategoryId UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    inParentCategoryId INT,
    stCategoryName NVARCHAR(200),
	flgIsActive BIT,
    dtCreatedDate DATETIME NOT NULL,
    inCreatedBy INT NOT NULL
)