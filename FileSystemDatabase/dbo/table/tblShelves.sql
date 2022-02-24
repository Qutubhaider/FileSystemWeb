CREATE TABLE tblShelves
(
    inShelvesId INT IDENTITY(1,1) PRIMARY KEY,
    unShelvesId UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    inZoneId INT,
    inDivisionId INT,
    intDepartmentId INT,
    inStoreId INT,
    inRoomId INT,
    inAlmirahId INT,
    stShelvesNumber NVARCHAR(200),
    dtCreateDate DATETIME NOT NULL,
    inCreatedBy INT NOT NULL
)