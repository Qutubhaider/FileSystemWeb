using FileSystemBAL.Data;
using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.Shelve.Models;
using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository
{
    public class ShelveRepository : IShelveRepository
    {
        private readonly DatabaseContext moDatabaseContext;
        private int fiSuccess;

        public ShelveRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }

        public void DeleteShelve(Guid fuAmirahId, out int fiSuccess)
        {
            throw new NotImplementedException();
        }

        public Shelve.Models.Shelve GetShelveDetail(Guid fuShelveId)
        {
            throw new NotImplementedException();
        }

        public List<Select2> GetShelveDropDown()
        {
            throw new NotImplementedException();
        }

        public List<ShelveListResult> GetShelveList(string fsShelveNumber, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize)
        {
            throw new NotImplementedException();
        }

        public void SaveShelve(Shelve.Models.Shelve foShelve, int fiUserId, out int fiSuccess)
        {
            throw new NotImplementedException();
        }
    }
}
