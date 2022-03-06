﻿-- =============================================
-- Author:  Qutub Haider
-- EXEC getState
-- =============================================
/*
Ref#	Modified By			Modified date			Description
*/
CREATE PROC [dbo].[getDesignationList]
(
	@stDesignationName NVARCHAR(211)=NULL,
	@inStatus INT=NULL,  
	@inSortColumn INT = NULL,
	@stSortOrder NVARCHAR(51) = NULL,
	@inPageNo INT = 1,
	@inPageSize INT = 10
)
AS
BEGIN
SET NOCOUNT ON;  
	SET @stDesignationName =REPLACE(@stDesignationName,'''','''''')
	DECLARE @stSQL AS NVARCHAR(MAX)
	DECLARE @stSort AS NVARCHAR(MAX) = 'stDesignationName'
	DECLARE @inStart INT, @inEnd INT

	SET @stSortOrder = ISNULL(@stSortOrder, 'DESC')
	SET @inStart  = (@inPageNo - 1) * @inPageSize + 1
	SET @inEnd  = @inPageNo * @inPageSize

	IF @inSortColumn = 1
	BEGIN
		SET @stSort = 'stDesignationName';
	END
	SET @stSQL=''+'WITH PAGED AS( 
		SELECT CAST(ROW_NUMBER() OVER(ORDER BY '+ @stSort + ' ' + ISNULL(@stSortOrder,'ASC') + ' ) AS INT) AS inRownumber,
		inDesignationId,unDesignationId,stDesignationName
		FROM (
	SELECT 
		D.inDesignationId,
		D.unDesignationId,
		D.stDesignationName
	FROM tblDesignation D WITH(NOLOCK)
	WHERE 1=1'

	IF(ISNULL(@stDesignationName,'')<>'')
		SET @stSQL = @stSQL + '  AND (D.stDesignationName LIKE ''%' + CONVERT(NVARCHAR(211), @stDesignationName)  + '%'')'
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




