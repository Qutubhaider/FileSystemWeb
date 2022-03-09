﻿-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 25-Feb-2022  
-- =============================================
--EXEC getDivisionDropDown
/*  
Ref# Modified By   Modified date   Description  
*/

CREATE PROCEDURE getStoreDropDown
(   
    @inStore INT
)
AS
BEGIN
SELECT inStoreId as id , stStoreName as value 
       FROM tblStore
       WHERE inStoreId=@inStore
END
