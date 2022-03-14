using FileSystemBAL.Data;
using FileSystemBAL.Room.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Models;
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
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext moDatabaseContext;

        public RoomRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }
        public void DeleteRoom(Guid fuRoomId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC deleteRoom @unRoomId={fuRoomId}, @inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public Room.Models.Room GetRoomDetail(Guid fuRoomId)
        {
            return moDatabaseContext.Set<Room.Models.Room>().FromSqlInterpolated($"EXEC getRoomDetail @unRoomId={fuRoomId}").AsEnumerable().FirstOrDefault();
        }

        public List<Select2> GetRoomDropDown(int fiStoreId)
        {
            return moDatabaseContext.Set<Select2>().FromSqlInterpolated($"EXEC getRoomDropDown @inStore={fiStoreId}").ToList();
        }

        public List<RoomListResult> GetRoomList(string fsRoomNumber, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize)
        {
            return moDatabaseContext.Set<RoomListResult>().FromSqlInterpolated($"EXEC getRoomList @stRoomNumber={fsRoomNumber}, @inSortColumn={fiSortColumn},@stSortOrder={fsSortOrder}, @inPageNo={fiPageNo},@inPageSize={fiPageSize}").ToList();
        }

        public void SaveRoom(Room.Models.Room foRoom, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveRoom @inRoomId={foRoom.inRoomId},  @stRoomNumber={foRoom.stRoomNumber} ,@inStoreId={foRoom.inStoreId},@inZoneId={foRoom.inZoneId},@inDivisionId={foRoom.inDivisionId},@inDepartmentId={foRoom.inDepartmentId},@inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }
    }
}
