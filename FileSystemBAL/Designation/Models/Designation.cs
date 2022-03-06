using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Designation.Models
{
    public class Designation
    {
        public int inDesignationId { get; set; }
        public Guid unDesignationId { get; set; }
        [Required(ErrorMessage ="Please enter designation name.")]
        public string stDesignationName { get; set; }
        public int inZoneId { get; set; }
        public int inDivisionId { get; set; }
        public int inDepartmentId { get; set; }
    }
}
