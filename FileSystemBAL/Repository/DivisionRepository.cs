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
    public class DivisionRepository : IDivisionRepository
    {
        private readonly DatabaseContext moDatabaseContext;

        public DivisionRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }
        public void DeleteDivision(Guid fuDivisionId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC deleteDivision @unDivisionId={fuDivisionId}, @inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public List<Division.Models.Division> GetAllDivision(string fsDivisionTitle, int? finStatus, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize)
        {
            return moDatabaseContext.Set<Division.Models.Division>().FromSqlInterpolated($"EXEC getAllDivision @stDivisionTile={fsDivisionTitle}, @inStatus={finStatus}, @inSortColumn={fiSortColumn},@stSortOrder={fsSortOrder}, @inPageNo={fiPageNo},@inPageSize={fiPageSize}").ToList();
        }

        public Division.Models.Division GetDivision(Guid fuDivisionId)
        {
            return moDatabaseContext.Set<Division.Models.Division>().FromSqlInterpolated($"EXEC getDivision @unDivisionId={fuDivisionId}").FirstOrDefault();
        }

        public void SaveDivision(Division.Models.Division foDivision, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveDivision @inDivistionId={foDivision.inDivisionId},@inStateId={foDivision.inStateId},@stDivistionName={foDivision.stDivisionName},@inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
    }
}
