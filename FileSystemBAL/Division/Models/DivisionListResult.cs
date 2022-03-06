using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Division.Models
{
    public class DivisionListResult
    {
		public int inRecordCount { get; set; }
		public int inRownumber { get; set; }
		public int inDivistionId { get; set; }
		public Guid unDivisionId { get; set; }
		public string stZoneName { get; set; }
		public string stDivistionName { get; set; }
	}
}
