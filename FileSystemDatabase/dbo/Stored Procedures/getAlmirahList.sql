﻿-- ============================================= 
-- Author: Vaibhav Singh
-- EXEC [[getRoomList]] 
-- ============================================= 
/* 
Ref#	Modified By			Modified date			Description 
*/ 
CREATE PROC [dbo].[getAlmirahList] 
( 
	@stAlmirahNumber NVARCHAR(211)=NULL,   
	@inSortColumn INT = NULL, 
	@stSortOrder NVARCHAR(51) = NULL, 
	@inPageNo INT = 1, 
	@inPageSize INT = 10 
) 
AS 
BEGIN 
SET NOCOUNT ON;   
	SET @stAlmirahNumber =REPLACE(@stAlmirahNumber,'''','''''') 
	DECLARE @stSQL AS NVARCHAR(MAX) 
	DECLARE @stSort AS NVARCHAR(MAX) = 'stAlmirahNumber' 
	DECLARE @inStart INT, @inEnd INT 
 
	SET @stSortOrder = ISNULL(@stSortOrder, 'DESC') 
	SET @inStart  = (@inPageNo - 1) * @inPageSize + 1 
	SET @inEnd  = @inPageNo * @inPageSize 
 
	IF @inSortColumn = 1 
	BEGIN 
		SET @stSort = 'stAlmirahNumber'; 
	END  
	SET @stSQL=''+'WITH PAGED AS(  
		SELECT CAST(ROW_NUMBER() OVER(ORDER BY '+ @stSort + ' ' + ISNULL(@stSortOrder,'ASC') + ' ) AS INT) AS inRownumber, 
		inAlmirahId,unAlmirahId,stAlmirahNumber,stZoneName ,stDivisionName,stDepartmentName,stRoomNumber
		FROM ( 
            SELECT  
                    A.inAlmirahId, 
                    A.unAlmirahId, 
                    A.stAlmirahNumber, 
                    Z.stZoneName,
					DV.stDivisionName,
					DP.stDepartmentName,
					R.stRoomNumber
            FROM tblAlmirah A WITH(NOLOCK) 
            JOIN tblZone Z ON Z.inZoneId=A.inZoneId
            JOIN tblDivision DV ON DV.inDivisionId=A.inDivisionId
            JOIN tblDepartment DP ON DP.inDepartmentId=A.inDepartmentId
			JOIN tblRoom R ON R.inRoomId=A.inRoomId
            WHERE 1=1' 
 
	IF(ISNULL(@stAlmirahNumber,'')<>'') 
		SET @stSQL = @stSQL + '  AND (A.stAlmirahNumber LIKE ''%' + CONVERT(NVARCHAR(211), @stAlmirahNumber)  + '%'')' 
 
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