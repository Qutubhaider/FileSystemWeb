using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Room.Models
{
    public class Room
    {
        public int inRoomId { get; set; }
        public Guid unRoomId { get; set; }
        public string stRoomNumber { get; set; }
        public int inZoneId { get; set; }
        public int inDivisionId { get; set; }
        public int inDepartmentId { get; set; }
        public int inDesignationId { get; set; }
        public int inStoreId { get; set; }
        [NotMapped]
        public List<Select2> ZoneList { get; set; }
        [NotMapped]
        public List<Select2> DivisionList { get; set; }
        [NotMapped]
        public List<Select2> DepartmentList { get; set; }
        [NotMapped]
        public List<Select2> DesignationList { get; set; }
        [NotMapped]
        public List<Select2> StoreList { get; set; }
    }
}
