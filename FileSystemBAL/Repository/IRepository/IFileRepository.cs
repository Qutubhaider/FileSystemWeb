using FileSystemBAL.FIle.Models;
using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
    public interface IFileRepository
    {
        void SaveFile(FileDetail foFileDetail, int fiUserId, out int fiSuccess);
        FileDetail GetFileDetail(Guid unFileId);
        List<FileListResult> GetFileList(string fsFileName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize);
        List<Select2> GetFileDropDown();

    }
}
