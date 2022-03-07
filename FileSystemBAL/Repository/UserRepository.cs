using FileSystemBAL.Data;
using FileSystemBAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public User.Models.UserEmailResult GetUserByEmail(string stEmail)
        {
            return moDatabaseContext.Set<User.Models.UserEmailResult>().FromSqlInterpolated($"EXEC getUserByEmail @stUserEmail={stEmail}").AsEnumerable().FirstOrDefault();
        }
    }
}
