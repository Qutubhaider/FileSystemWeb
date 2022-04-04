using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
   public interface IUserRepository
    {
        public User.Models.UserEmailResult GetUserByEmail(string stEmail);
        public void InserUserProfile(User.Models.UserProfile foUserProfile, int fiUserId, out int fiSuccess);
        User.Models.UserProfile GetUserDetail(Guid fuUserId);
        void DeleteUser(Guid fuUserId, out int fiSuccess);
        List<User.Models.UserListResult> GetUserList(string fsUserName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize,int? fiUserId=null);
        List<Select2> GetUserDropDown();
        List<Select2> GetUserListForIssueFile(int fiStoreId,int inDivisionId);
        List<Select2> GetUserListByDivisionId(int fiDivisionId);

    }
}
