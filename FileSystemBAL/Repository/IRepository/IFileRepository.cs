using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
    public interface IFileRepository
    {
        void SaveFile(FIle.Models.FileDetail foFileDetail, int fiUserId, out int fiSuccess);
    }
}
