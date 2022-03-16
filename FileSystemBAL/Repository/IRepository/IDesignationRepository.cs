using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
    public interface IDesignationRepository
    {
        void SaveDesignation(Designation.Models.Designation foDesignation, int fiUserId, out int fiSuccess);
        Designation.Models.Designation GetDesignation(Guid fuDesignationId);
        void DeleteDepartment(Guid fuDesignationId, out int fiSuccess);
        List<Designation.Models.DesignationListResult> GetDesignationList(string stDesignationName, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize);
        List<Select2> GetDesignationDropDown(int fiDepartmentId);
    }
}
