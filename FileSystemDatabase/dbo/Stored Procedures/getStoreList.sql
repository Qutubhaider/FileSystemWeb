-- ============================================= 
-- Author:  Qutub Haider 
-- EXEC [[getStoreList]] 
-- ============================================= 
/* 
Ref#	Modified By			Modified date			Description 
*/ 
CREATE PROC [dbo].[getStoreList] 
( 
	@stStoreName NVARCHAR(211)=NULL,   
	@inSortColumn INT = NULL, 
	@stSortOrder NVARCHAR(51) = NULL, 
	@inPageNo INT = 1, 
	@inPageSize INT = 10 
) 
AS 
BEGIN 
SET NOCOUNT ON;   
	SET @stStoreName =REPLACE(@stStoreName,'''','''''') 
	DECLARE @stSQL AS NVARCHAR(MAX) 
	DECLARE @stSort AS NVARCHAR(MAX) = 'stStoreName' 
	DECLARE @inStart INT, @inEnd INT 
 
	SET @stSortOrder = ISNULL(@stSortOrder, 'DESC') 
	SET @inStart  = (@inPageNo - 1) * @inPageSize + 1 
	SET @inEnd  = @inPageNo * @inPageSize 
 
	IF @inSortColumn = 1 
	BEGIN 
		SET @stSort = 'stStoreName'; 
	END  
	SET @stSQL=''+'WITH PAGED AS(  
		SELECT CAST(ROW_NUMBER() OVER(ORDER BY '+ @stSort + ' ' + ISNULL(@stSortOrder,'ASC') + ' ) AS INT) AS inRownumber, 
		inStoreId,unStoreId,stStoreName,stZoneName ,stDivisionName,stDepartmentName,stDesignationName
		FROM ( 
            SELECT  
                    S.inStoreId, 
                    S.unStoreId, 
                    S.stStoreName, 
                    Z.stZoneName,
					DV.stDivisionName,
					DP.stDepartmentName,
					DS.stDesignationName
            FROM tblStore S WITH(NOLOCK) 
            JOIN tblZone Z ON Z.inZoneId=D.inZoneId
            JOIN tblDivision DV ON DV.inDivisionId=D.inDivisionId
            JOIN tblDepartment DP ON DP.inDepartmentId=D.inDepartmentId
            JOIN tblDesignation DS ON DS.inDesignationId=D.inDesignationId
            WHERE 1=1' 
 
	IF(ISNULL(@stStoreName,'')<>'') 
		SET @stSQL = @stSQL + '  AND (D.stDeskName LIKE ''%' + CONVERT(NVARCHAR(211), @stStoreName)  + '%'')' 
 
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
 