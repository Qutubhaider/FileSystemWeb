-- =============================================  
-- Author:   Vaibhav Singh
-- Create Date: 11-MAR-22 
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/ 

CREATE PROCEDURE [dbo].[saveIssueFileHistory]
(  
@inIssueFileId	INT=NULL,																																	
@inStoreFileId			INT,																
@inUserId			INT,																															
@inDivisionId		INT,													
@inDepartmentId		INT,																																
@dtIssueDate		DateTime,																						
@stComment		NVARCHAR(200),
@inStatus           INT,
@inCreatedBy        INT,
@inSuccess INT OUT
)
AS
 BEGIN
  DECLARE @currentDateTime DATETIME=getDate()
  SET @inSuccess=0
	IF(ISNULL(@inIssueFileId,0)=0)  
		 BEGIN 			
				INSERT INTO tblIssueFileHistory(inStoreFileDetailsId,inAssignUserId,inDivisionId,inDepartmentId,dtIssueDate,stComment,inStatus,dtCreateDate,inCreatedBy)  
				SELECT  @inStoreFileId,@inUserId,@inDivisionId,@inDepartmentId,@dtIssueDate,@stComment,@inStatus,@currentDateTime, @inCreatedBy  
				SET @inSuccess=101  
		 END
    ELSE
		BEGIN
		UPDATE tblIssueFileHistory
		SET
		inAssignUserId        =     @inUserId		,
		inDivisionId 			=   @inDivisionId	,
		inDepartmentId			=   @inDepartmentId	,
		inStoreFileDetailsId	 =  @inStoreFileId	,
		dtIssueDate 			=  @dtIssueDate		,
		stComment 				 = @stComment		,
		inStatus 				=  @inStatus   		,       			  
		dtCreateDate    =          @currentDateTime,
		inCreatedBy =@inCreatedBy
		WHERE @inIssueFileId=@inIssueFileId
		SET @inSuccess=102
		END
 END
