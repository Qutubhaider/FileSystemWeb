-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 11-MAR-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/
CREATE PROCEDURE getUserDataByDropDown(
@inUserId UNIQUEIDENTIFIER
)
AS
BEGIN
  SELECT inUserProfileId,inUserId,stFirstName,stLastName,stEmail,stMobile,stAddress from tblUserProfile
  WHERE inUserProfileId = @inUserId
END
