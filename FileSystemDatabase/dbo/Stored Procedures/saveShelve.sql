-- =============================================  
-- Author:   Vaibhav Singh
-- Create Date: 11-MAR-22 
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/  
CREATE PROC [dbo].[saveShelve]  
(  
	 @inShelveId INT=NULL,  
	 @stShelveNumber nvarchar(200),
	 @inZoneId INT,
	 @inDivisionId INT,
	 @inDepartmentId INT,
	 @inStoreId INT,
	 @inRoomId INT,
	 @inAlmirahId INT,
	 @inCreatedBy INT,  
	 @inSuccess INT OUT
)  
AS  
BEGIN TRY  
SET NOCOUNT ON;     
 DECLARE @getDateTimeByTimezone DATETIME =getDate()  
 SET @inSuccess=0 
	BEGIN TRAN  
	
		 IF(ISNULL(@inShelveId,0)=0)  
		 BEGIN 			
				INSERT INTO tblShelves(stShelveNumber,inZoneId,inDivisionId,inDepartmentId,inStoreId,inRoomId,inAlmirahId,dtCreateDate,inCreatedBy)  
				SELECT  @stShelveNumber, @inZoneId,@inDivisionId,@inDepartmentId,@inStoreId,@inRoomId,@inAlmirahId ,@getDateTimeByTimezone, @inCreatedBy  
				SET @inSuccess=101  
		 END
		 ELSE  
		 BEGIN  
				  UPDATE tblShelves WITH(ROWLOCK) SET   
						stShelveNumber=@stShelveNumber,
						inZoneId=@inZoneId,
						inDivisionId=@inDivisionId,
						inDepartmentId= @inDepartmentId,
						inStoreId=@inStoreId,
						inRoomId=@inRoomId,
						dtCreateDate=@getDateTimeByTimezone,
						inCreatedBy=@inCreatedBy					 
				  WHERE inShelvesId=@inShelveId
				  SET @inSuccess=102   		   
			 END  		
	COMMIT TRAN;  
END TRY  
BEGIN CATCH  
 set @inSuccess=0  
 ROLLBACK TRAN; 
END CATCH