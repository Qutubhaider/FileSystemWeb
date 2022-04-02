using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Case.Models
{
    public class CaseDetailResult
    {
        public int inCaseId { get; set; }
        public Guid unCaseId { get; set; }
        public string stFileName { get; set; }
        public string stEmployeeName { get; set; }
        public string stEmployeeNumber { get; set; }
        public int inStatus { get; set; }
    }
}
