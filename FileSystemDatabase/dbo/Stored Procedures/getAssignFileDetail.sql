-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 11-MAR-2022  
-- EXEC getAssignFileDetail '9d165e2e-3a65-4917-85de-7eff3a0aaeba'
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/
CREATE PROCEDURE getAssignFileDetail(
@unAssignFileId UNIQUEIDENTIFIER
)
AS
BEGIN
  SELECT IFH.unlssueFileId,IFH.stComment,F.stFileName,DV.stDivisionName,UP.stFirstName +' '+UP.stLastName AS stUserName,DP.stDepartmentName
  FROM tblIssueFileHistory IFH
            JOIN tblDivision DV ON DV.inDivisionId=IFH.inDivisionId
            JOIN tblUserProfile UP ON UP.inUserProfileId=IFH.inAssignUserId
            JOIN tblStoreFileDetails F ON F.inStoreFileDetailsId=IFH.inStoreFileDetailsId
            JOIN tblDepartment DP ON DP.inDepartmentId=IFH.inDepartmentId
  WHERE unlssueFileId=@unAssignFileId
END
