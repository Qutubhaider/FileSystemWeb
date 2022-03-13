
-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 11-MAR-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/
CREATE PROCEDURE getUserDetail(
@unUserProfileId UNIQUEIDENTIFIER
)
AS
BEGIN
  SELECT inUserProfileId,unUserProfileId,inUserId,inZoneId,inDivisionId,inDeskid,inDepartmentId,inDesignationId,stFirstName,stLastName,stEmail,stMobile,stAddress,inStatus FROM tblUserProfile
  WHERE unUserProfileId=@unUserProfileId
END
