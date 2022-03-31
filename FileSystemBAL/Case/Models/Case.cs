using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Case.Models
{
    public class Case
    {
        public int inCaseId { get; set; } 
        public Guid unCaseId { get; set; } 
        public int inZoneId { get; set; } 
        public int inDivisionId { get; set; } 
        public int inDepartmentId { get; set; } 
        public int inDesignationId { get; set; } 
        public int inStoreFileDetailId { get; set; } 
        public int inStatus { get; set; } 
        public string stComment { get; set; } 
        
    }
}
