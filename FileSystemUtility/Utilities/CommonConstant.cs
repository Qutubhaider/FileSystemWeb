using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemUtility.Utilities
{
    public class CommonConstant
    {
        public class SessionConstant
        {
            public const string Id = "Id";
            public const string unUserId = "unUserId";
            public const string stUserName = "stUserName";
            public const string stEmail = "stEmail";
            public const string RoleId = "RoleId";
        }

        public class RoleConstants
        {

            public const string Admin = "Admin";
            public const string DivisionAdmin = "Division Admin";
            public const string DepartmentAdmin = "Department Admin";
            public const string DeskAdmin = "Desk Admin";
            public const string DeskOP = "Desk OP";
            public const string StoreOP = "Store OP";
        }

        public enum UserType
        {
            Admin = 1,
            DivisionAdmin = 2,
            DepartmentAdmin = 3,
            DeskAdmin = 4,
            DeskOP = 5,
            StoreOP = 6
        }
    }
}