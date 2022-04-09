using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.IssueFIleHistory.Models
{
    public class IssueFileListResult
    {
        public int inRecordCount { get; set; }
        public int inRownumber { get; set; }
        public int inlssueFileId { get; set; }
        public Guid unlssueFileId { get; set; }
        public DateTime dtIssueDate { get; set; }
        public string stComment { get; set; }
        public int inStatus { get; set; }
        public string stFileName { get; set; }
        public string stDivisionName  { get; set; }
        public string stFirstName  { get; set; }
        public string stDepartmentName { get; set; }
        public int inSRId { get; set; }
    }
}
