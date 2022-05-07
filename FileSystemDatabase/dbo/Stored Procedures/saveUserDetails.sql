﻿ALTER PROCEDURE [dbo].[saveUserDetails](
@inDeskid INT,  -- INT,
@inZoneId INT,
@inStoreId INT,   
@inDivisionId INT,
@inDepartmentId INT,
@inDesignationId INT,
@stFirstName NVARCHAR(200),
@stLastName NVARCHAR(200),
@stEmail NVARCHAR(200),
@stMobile NVARCHAR(200),
@stAddress NVARCHAR(200),
@inEmployeeType INT,
@stPFNumber NVARCHAR(200),
@stEmployeeNumber NVARCHAR(200),
@stPPONumber NVARCHAR(200),
@inStatus INT,  --
@inSuccess INT OUT
)
	
AS
BEGIN

 INSERT INTO tblUser(stUsername,stPassword,inRole,stEmail,stMobile,inStatus,flgIsDeleted,dtCreateDate,inCreatedBy)
 SELECT @stEmail,'pass@123',7,@stEmail,@stMobile,@inStatus,0,GetDate(),1

 INSERT INTO tblUserDetails(inUserId,inDeskid,inZoneId ,inStoreId , inDivisionId ,inDepartmentId ,inDesignationId ,stFirstName ,stLastName,stEmail,stMobile ,stAddress , inEmployeeType, stPFNumber ,stEmployeeNumber ,stPPONumber,inStatus ,flgIsDeleted ,dtCreateDate,inCreatedBy)
 SELECT SCOPE_IDENTITY(),@inDeskid,@inZoneId ,@inStoreId , @inDivisionId ,@inDepartmentId ,@inDesignationId ,@stFirstName ,@stLastName,@stEmail,@stMobile ,@stAddress , 2inEmployeeType, @stPFNumber ,@stEmployeeNumber ,@stPPONumber,1 ,0 ,GetDate(),0



END