-- =============================================  
-- Author:   Vaibhav Singh
-- Create Date: 11-MAR-22 
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/  
CREATE PROC [dbo].[saveRoom]  
(  
	 @inRoomId INT=NULL,  
	 @stRoomName nvarchar(200),
	 @inZoneId INT,
	 @inDivisionId INT,
	 @inDepartmentId INT,
	 @inStoreId INT,
	 @inCreatedBy INT,  
	 @inSuccess INT OUT
)  
AS  
BEGIN TRY  
SET NOCOUNT ON;     
 DECLARE @getDateTimeByTimezone DATETIME =getDate()  
 SET @inSuccess=0 
	BEGIN TRAN  
	
		 IF(ISNULL(@inRoomId,0)=0)  
		 BEGIN 			
				INSERT INTO tblRoom(stRoomNumber,inZoneId,inDivisionId,inDepartmentId,dtCreateDate,inCreatedBy)  
				SELECT  @stRoomName, @inZoneId,@inDivisionId,@inDepartmentId, @getDateTimeByTimezone, @inCreatedBy  
				SET @inSuccess=101  
		 END
		 ELSE  
		 BEGIN  
				  UPDATE tblRoom WITH(ROWLOCK) SET   
						stRoomNumber=@stRoomName,
						inZoneId=@inZoneId,
						inDivisionId=@inDivisionId,
						inDepartmentId= @inDepartmentId,
						dtCreateDate=@getDateTimeByTimezone,
						inCreatedBy=@inCreatedBy					 
				  WHERE inDivisionId=@inDivisionId
				  SET @inSuccess=102   		   
			 END  		
	COMMIT TRAN;  
END TRY  
BEGIN CATCH  
 set @inSuccess=0  
 ROLLBACK TRAN; 
END CATCH