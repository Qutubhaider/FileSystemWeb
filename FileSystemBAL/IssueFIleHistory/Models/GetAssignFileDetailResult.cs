using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.IssueFIleHistory.Models
{
    public class GetAssignFileDetailResult
    {
        public Guid unlssueFileId { get; set; }
        public string stComment { get; set; }
        public string stFileName { get; set; }
        public string stDivisionName { get; set; }
        public string stUserName { get; set; }
        public string stDepartmentName { get; set; }
    }
}
