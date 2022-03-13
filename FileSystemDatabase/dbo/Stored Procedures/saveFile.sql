﻿-- =============================================  
-- Author:   Vaibhav Singh
-- Create Date: 11-MAR-22 
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/  
CREATE PROC [dbo].[saveFile]  
(  
@inStoreFileDetails	INT=NULL,																																	
@inStoreId			INT,																
@inUserId			INT,																
@inZoneId			INT,															
@inDivisionId		INT,													
@inDepartmentId		INT,																							
@inRoomId			INT,									
@inAlmirahId		INT,											
@inShelvesId		INT,											
@stFileName		    NVARCHAR(200),
@stEmployeeName		NVARCHAR(200),
@stPPONumber		NVARCHAR(200),
@stPFNumber			NVARCHAR(200),
@stEmployeeNumber	NVARCHAR(200),
@stMobile			NVARCHAR(200),
@inStatus           INT,
@inCreatedBy        INT,
@inSuccess INT OUT
)
AS
 BEGIN
  DECLARE @currentDateTime DATETIME=getDate()
  SET @inSuccess=0
	IF(ISNULL(@inStoreFileDetails,0)=0)  
		 BEGIN 			
				INSERT INTO tblStoreFileDetails(inStoreId,inUserId,inZoneId,inDivisionId,inDepartmentId,inRoomId,inAlmirahId,inShelvesId,stFileName,stEmployeeName,
				stPPONumber,stPFNumber,stEmployeeNumber,stMobile,inStatus,dtCreateDate,inCreatedBy)  
				SELECT  @inStoreId,@inUserId,@inZoneId,@inDivisionId,@inDepartmentId,@inRoomId,@inAlmirahId,@inShelvesId,@stFileName,@stEmployeeName,@stPPONumber,@stPFNumber,@stEmployeeNumber,
				        @stMobile,@inStatus,@currentDateTime, @inCreatedBy  
				SET @inSuccess=101  
		 END
 END