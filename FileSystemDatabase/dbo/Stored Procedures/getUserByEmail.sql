

CREATE PROCEDURE getUserByEmail(
@stUserEmail NVARCHAR(200)
)
AS
BEGIN
  SELECT inUserId,unUserId,stUsername,stEmail,stMobile , stPassword,inRole,inStatus FROM tblUser
  WHERE stEmail = @stUserEmail
END