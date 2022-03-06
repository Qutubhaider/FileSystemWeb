using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileSystemBAL.Division.Models
{
	public class Division
	{
		public int? inDivisionId { get; set; }
		public Guid? unDivisionId { get; set; }
		public int inZoneId { get; set; }
		public string stDivisionName { get; set; }
		[NotMapped]
		public List<Select2> ZoneList { get; set; }
	}
}

