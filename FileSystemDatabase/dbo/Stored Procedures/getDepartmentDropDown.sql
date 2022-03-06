﻿-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 25-Feb-2022  
-- =============================================
--EXEC getDivisionDropDown
/*  
Ref# Modified By   Modified date   Description  
*/

CREATE PROCEDURE getDepartmentDropDown
(   
    @inDivisionId INT
)
AS
BEGIN
SELECT inDepartmentId as id , stDepartmentName as value 
       FROM tblDepartment
       WHERE inDepartmentId=@inDivisionId
END
