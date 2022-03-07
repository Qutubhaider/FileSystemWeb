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
    }
}
