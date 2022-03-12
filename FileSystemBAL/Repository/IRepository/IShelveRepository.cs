using FileSystemBAL.Shelve.Models;
using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
    public interface IShelveRepository
    {
        void SaveShelve(Shelve.Models.Shelve foShelve, int fiUserId, out int fiSuccess);
        Shelve.Models.Shelve GetShelveDetail(Guid fuShelveId);
        void DeleteShelve(Guid fuAmirahId, out int fiSuccess);
        List<ShelveListResult> GetShelveList(string fsShelveNumber, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize);
        List<Select2> GetShelveDropDown();
    }
}
