-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 25-Feb-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/

CREATE PROCEDURE getUserListByDepartmentId(
@inDepartmentId INT
)
AS
BEGIN
SELECT inUserProfileId as id , stFirstName+' '+stLastName as value 
       FROM tblUserProfile
       WHERE inDepartmentId=@inDepartmentId
END