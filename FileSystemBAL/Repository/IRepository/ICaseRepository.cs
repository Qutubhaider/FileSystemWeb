using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
    public interface ICaseRepository
    {
        void SaveCase(Case.Models.Case foCase, int fiUserId, out int fiSuccess);
        Case.Models.Case GetCaseDetail(Guid fuCaseId);
        void DeleteCase(Guid fuCaseId, out int fiSuccess);
        //List<CaseListResult> GetCaseList(string fsCaseNumber, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize, int? fiUserId = null);
        //List<Select2> GetCaseDropDown(int fiRoomId);
    }
}
