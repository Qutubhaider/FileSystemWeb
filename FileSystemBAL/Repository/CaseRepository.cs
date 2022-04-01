using FileSystemBAL.Data;
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
    public class CaseRepository : ICaseRepository
    {
        private readonly DatabaseContext moDatabaseContext;
        private int fiSuccess;

        public CaseRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }
        public void DeleteCase(Guid fuCaseId, out int fiSuccess)
        {
            throw new NotImplementedException();
        }

        public Case.Models.Case GetCaseDetail(Guid fuCaseId)
        {
            throw new NotImplementedException();
        }

        public void SaveCase(Case.Models.Case foCase, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC acceptAssignFile @inZoneId={foCase.inZoneId},@inDivisionId={foCase.inDivisionId},@inDepartmentId={foCase.inDepartmentId},@inDesignationId={foCase.inDesignationId},@inStoreFileDetailId={foCase.inStoreFileDetailId},@inStatus={1},@stComment={foCase.stComment},@inAcceptedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
            
        }
    }
}
