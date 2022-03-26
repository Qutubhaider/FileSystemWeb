
-- =============================================   
-- Author:   Qutub Haider 
-- Create Date: 20-mar-22   
-- =============================================   
 
CREATE PROCEDURE getUserByEmail( 
@stUserEmail NVARCHAR(200) 
) 
AS 
BEGIN
SELECT U.inUserId,U.unUserId,U.inStatus,U.inRole,U.stEmail,U.stMobile,U.stPassword,U.stUsername,UP.inDeskid,UP.inDivisionId,UP.inDesignationId,UP.inZoneId,UP.inStoreId,UP.inDepartmentId
FROM tblUser U
JOIN tblUserProfile UP ON UP.inUserId = U.inUserId 
WHERE U.stEmail=@stUserEmail 
END 
