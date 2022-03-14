-- =============================================  
-- Author:   Vaibhav Singh 
-- Create Date: 6-mar-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/  


CREATE PROCEDURE getFileDetail(
@unFileId UNIQUEIDENTIFIER
)
AS
BEGIN
  SELECT inStoreFileDetailsId,unStoreFileDetailsId,inStoreId,inUserId,inZoneId,inDivisionId,inDepartmentId,inRoomId,inAlmirahId,inShelvesId,stFileName,stEmployeeName,
				stPPONumber,stPFNumber,stEmployeeNumber,stMobile,inStatus FROM tblStoreFileDetails
  WHERE unStoreFileDetailsId=@unFileId
END