-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 11-MAR-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/
CREATE PROCEDURE getFileDetailFromDropDown(
@inStoreFileId INT
)
AS
BEGIN
  SELECT inStoreFileDetailsId,stFileName,stEmployeeName,stEmployeeNumber,stPFNumber,stMobile,stPPONumber from tblStoreFileDetails
  WHERE inStoreFileDetailsId = @inStoreFileId
END
