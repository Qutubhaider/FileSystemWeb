﻿using FileSystemBAL.Data;
using FileSystemBAL.IssueFIleHistory;
using FileSystemBAL.IssueFIleHistory.Models;
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
    public class IssueFileHistoreyRepository : IIssueFileHistoryRepository
    {
        private readonly DatabaseContext moDatabaseContext;
        private int fiSuccess;

        public IssueFileHistoreyRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }
        public IssueFile GetIssueFileDetail(Guid fuIssueFileId)
        {
            return moDatabaseContext.Set<IssueFile>().FromSqlInterpolated($"EXEC getIssueFileDetail @unIssueFileDetail={fuIssueFileId}").AsEnumerable().FirstOrDefault();
        }

        public List<IssueFileListResult> GetIssueFileList(string fsFileName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize, int? fiUserId = null, int? fiDepartmentId = null, int? fiDivisionId = null)
        {
            return moDatabaseContext.Set<IssueFileListResult>().FromSqlInterpolated($"EXEC getIssueFileList @stFileName={fsFileName}, @inSortColumn={fiSortColumn},@stSortOrder={fsSortOrder}, @inPageNo={fiPageNo},@inPageSize={fiPageSize},@inUserId={fiUserId},@inDepartmentId={fiDepartmentId},@inDivisionId={fiDivisionId}").ToList();
        }

        public void SaveIssueFile(IssueFile foIssueFile, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveIssueFileHistory @inIssueFileId={foIssueFile.inlssueFileId},@inStoreFileId={foIssueFile.inStoreFileDetailsId} ,@inDivisionId={foIssueFile.inDivisionId},@inDepartmentId={foIssueFile.inDepartmentId},@inUserId={foIssueFile.inAssignUserId},@dtIssueDate={foIssueFile.dtIssueDate},@stComment={foIssueFile.stComment},@inStatus={foIssueFile.inStatus},@inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public GetAssignFileDetailResult AssignFileDetailResult(Guid? fuAssignFileId)
        {
            return moDatabaseContext.Set<GetAssignFileDetailResult>().FromSqlInterpolated($"EXEC getAssignFileDetail @unAssignFileId={fuAssignFileId}").AsEnumerable().FirstOrDefault();
        }
    }
}
