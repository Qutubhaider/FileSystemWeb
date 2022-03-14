using FileSystemBAL.Data;
using FileSystemBAL.FIle.Models;
using FileSystemBAL.Repository.IRepository;
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
    public class FileRepository:IFileRepository
    {
        private readonly DatabaseContext moDatabaseContext;
        private int fiSuccess;

        public FileRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }

        public FileDetail GetFileDetail(Guid unFileId)
        {
            return moDatabaseContext.Set<FileDetail>().FromSqlInterpolated($"EXEC getFileDetail @@unFileId={unFileId}").AsEnumerable().FirstOrDefault();
        }

        public List<FileListResult> GetFileList(string fsFileName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize)
        {
        return moDatabaseContext.Set<FileListResult>().FromSqlInterpolated($"EXEC getFileList @@stFileName={fsFileName}, @inSortColumn={fiSortColumn},@stSortOrder={fsSortOrder}, @inPageNo={fiPageNo},@inPageSize={fiPageSize}").ToList();
    }

        public void SaveFile(FileDetail foFileDetail, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveFile @inStoreFileDetails={foFileDetail.inStoreFileDetail},@inStoreId={foFileDetail.inStoreId},@inUserId={foFileDetail.inUserId},@inZoneId={foFileDetail.inZoneId},@inDivisionId={foFileDetail.inDivisionId},@inDepartmentId={foFileDetail.inDepartmentId},@inRoomId={foFileDetail.inRoomId},@inAlmirahId={foFileDetail.inAlmirahId},@inShelvesId={foFileDetail.inShelvesId},@stFileName={foFileDetail.stFileName},@stEmployeeName={foFileDetail.stEmployeeName},@stPPONumber={foFileDetail.stPPONumber},@stPFNumber={foFileDetail.stPFNumber},@stEmployeeNumber={foFileDetail.stEmployeeNumber},@stMobile={foFileDetail.stMobile},@inStatus={foFileDetail.inStatus}, @inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
    }
}
