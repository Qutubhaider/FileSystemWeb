-- =============================================  
-- Author:   Vaibhav Singh 
-- Create Date: 6-mar-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/  


CREATE PROCEDURE getIssueFileDetail(
@unIssueFileDetail UNIQUEIDENTIFIER
)
AS
BEGIN
  SELECT inlssueFileId,unlssueFileId,inAssignUserId,inDivisionId,inDepartmentId,inStoreFileDetailsId,dtIssueDate,stComment,inStatus FROM tblIssueFileHistory
  WHERE unlssueFileId=@unIssueFileDetail
END