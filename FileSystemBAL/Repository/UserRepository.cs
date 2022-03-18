using FileSystemBAL.Data;
using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.Store.Models;
using FileSystemBAL.User.Models;
using FileSystemUtility.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DatabaseContext moDatabaseContext;

        public UserRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }

        public void DeleteUser(Guid fuUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC deleteUser @unUserId={fuUserId}, @inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public List<Select2> GetUserDropDown()
        {
            return moDatabaseContext.Set<Select2>().FromSqlInterpolated($"EXEC getUserDropDown").ToList();
        }

        public UserEmailResult GetUserByEmail(string stEmail)
        {
            return moDatabaseContext.Set<UserEmailResult>().FromSqlInterpolated($"EXEC getUserByEmail @stUserEmail={stEmail}").AsEnumerable().FirstOrDefault();
        }

        public UserProfile GetUserDetail(Guid fuUserId)
        {
            return moDatabaseContext.Set<UserProfile>().FromSqlInterpolated($"EXEC getUserDetail @unUserProfileId={fuUserId}").AsEnumerable().FirstOrDefault();
        }

        public List<UserListResult> GetUserList(string fsStoreName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize)
        {
            return moDatabaseContext.Set<UserListResult>().FromSqlInterpolated($"EXEC getUserList @stUserName={fsStoreName}, @inSortColumn={fiSortColumn},@stSortOrder={fsSortOrder}, @inPageNo={fiPageNo},@inPageSize={fiPageSize}").ToList();
        }

        public void InserUserProfile(UserProfile foUserProfile, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC insertUserProfile @inUserProfileId={foUserProfile.inUserProfileId},@inDeskid={foUserProfile.inDeskid},@inUserId={foUserProfile.inUserId},@inZoneId={foUserProfile.inZoneId},@inDivisionId={foUserProfile.inDivisionId},@inDepartmentId={foUserProfile.inDepartmentId},@inDesignationId={foUserProfile.inDesignationId},@stFirstName={foUserProfile.stFirstName},@stLastName={foUserProfile.stLastName},@stEmail={foUserProfile.stEmail},@stMobile={foUserProfile.stMobile},@stAddress={foUserProfile.stAddress},@inStatus={foUserProfile.inStatus}, @inCreatedBy ={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
    }
}
