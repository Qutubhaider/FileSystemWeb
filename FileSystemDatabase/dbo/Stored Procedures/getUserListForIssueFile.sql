-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 25-Feb-2022  
-- =============================================
--EXEC getDeskDropDown
/*  
Ref# Modified By   Modified date   Description  
*/

CREATE PROCEDURE getUserListForIssueFile
(   
     @inStoreId INT
)
AS
BEGIN
SELECT inUserProfileId as id , stFirstName+' '+stLastName as value 
       FROM tblUserProfile
       WHERE inStoreId=@inStoreId
END
