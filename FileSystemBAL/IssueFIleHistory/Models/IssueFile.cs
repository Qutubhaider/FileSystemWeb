using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.IssueFIleHistory.Models
{
   public class IssueFile
    {
        public int inlssueFileId { get; set; }
        public Guid unlssueFileId { get; set; }
        public int inAssignUserId { get; set; }
        public int inDivisionId { get; set; }
        public int inDepartmentId { get; set; }
        public int inStoreFileDetailsId { get; set; }
        public DateTime dtIssueDate { get; set; }
        public string stComment { get; set; }
        public int inStatus { get; set; }
        [NotMapped]
        public List<Select2> DepartmentList { get; set; }
        [NotMapped]
        public List<Select2> UserList { get; set; }
        [NotMapped]
        public List<Select2> FileList { get; set; }

    }
}
