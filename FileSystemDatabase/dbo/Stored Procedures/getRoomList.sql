-- ============================================= 
-- Author: Vaibhav Singh
-- EXEC [[getRoomList]] 
-- ============================================= 
/* 
Ref#	Modified By			Modified date			Description 
*/ 
CREATE PROC [dbo].[getRoomList] 
( 
	@stRoomNumber NVARCHAR(211)=NULL,   
	@inSortColumn INT = NULL, 
	@stSortOrder NVARCHAR(51) = NULL, 
	@inPageNo INT = 1, 
	@inPageSize INT = 10 
) 
AS 
BEGIN 
SET NOCOUNT ON;   
	SET @stRoomNumber =REPLACE(@stRoomNumber,'''','''''') 
	DECLARE @stSQL AS NVARCHAR(MAX) 
	DECLARE @stSort AS NVARCHAR(MAX) = 'stStoreName' 
	DECLARE @inStart INT, @inEnd INT 
 
	SET @stSortOrder = ISNULL(@stSortOrder, 'DESC') 
	SET @inStart  = (@inPageNo - 1) * @inPageSize + 1 
	SET @inEnd  = @inPageNo * @inPageSize 
 
	IF @inSortColumn = 1 
	BEGIN 
		SET @stSort = 'stRoomNumber'; 
	END  
	SET @stSQL=''+'WITH PAGED AS(  
		SELECT CAST(ROW_NUMBER() OVER(ORDER BY '+ @stSort + ' ' + ISNULL(@stSortOrder,'ASC') + ' ) AS INT) AS inRownumber, 
		inRoomId,unRoomId,stRoomNumber,stZoneName ,stDivisionName,stDepartmentName,stDesignationName
		FROM ( 
            SELECT  
                    R.inRoomId, 
                    R.unRoomId, 
                    R.stRoomNumber, 
                    Z.stZoneName,
					DV.stDivisionName,
					DP.stDepartmentName,
					DS.stDesignationName
            FROM tblRoom R WITH(NOLOCK) 
            JOIN tblZone Z ON Z.inZoneId=R.inZoneId
            JOIN tblDivision DV ON DV.inDivisionId=R.inDivisionId
            JOIN tblDepartment DP ON DP.inDepartmentId=R.inDepartmentId
            JOIN tblDesignation DS ON DS.inDesignationId=R.inDesignationId
            WHERE 1=1' 
 
	IF(ISNULL(@stRoomNumber,'')<>'') 
		SET @stSQL = @stSQL + '  AND (R.stRoomNumber LIKE ''%' + CONVERT(NVARCHAR(211), @stRoomNumber)  + '%'')' 
 
 +'' 
 
	SET @stSQL = @stSQL +' 
				)A )   
				SELECT (SELECT CAST(COUNT(*) AS INT) FROM PAGED) AS inRecordCount,*   
				FROM PAGED '  
					 
	SET @stSQL = @stSQL + '	 
				WHERE PAGED.inRownumber BETWEEN ' + CONVERT(NVARCHAR(11), @inStart) + ' AND ' + CONVERT(NVARCHAR(11), @inEnd) + ' ' 
 
	PRINT(@stSQL) 
	EXEC (@stSQL) 
END 
 