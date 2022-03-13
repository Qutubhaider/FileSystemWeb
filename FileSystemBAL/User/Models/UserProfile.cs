using FileSystemUtility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.User.Models
{
    public class UserProfile
    {
        public int inUserProfileId { get; set; } 
        public Guid unUserProfileId { get; set; } 
        public int inDeskid { get; set; }
        public int inUserId { get; set; }
        public int inZoneId { get; set; }
        public int inDivisionId { get; set; }
        public int inDepartmentId { get; set; }
        public int inDesignationId { get; set; }
        public string stFirstName {get;set;}
        public string stLastName  {get;set;}
        public string stEmail     {get;set;}
        public string stMobile    {get;set;}
        public string stAddress { get; set; }
        public int inStatus { get; set; }
        [NotMapped]
        public List<Select2> DeskList { get; set; }
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
        [NotMapped]
        public List<Select2> RoomList { get; set; }
        [NotMapped]
        public List<Select2> AlmirahList { get; set; }
        [NotMapped]
        public List<Select2> ShelveList { get; set; }
    }
}
