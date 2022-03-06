-- =============================================  
-- Author: Vaibhav Singh  
-- Create Date: 25-Feb-2022  
-- =============================================  
/*  
Ref# Modified By   Modified date   Description  
*/

CREATE PROCEDURE getDesignationDropDown
AS
BEGIN
SELECT inDesignationId as id , stDesignationName as value 
       FROM tblDesignation

END