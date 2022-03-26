﻿using FileSystemUtility.Models;
using FileSystemUtility.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Please select role.")]
        public int inRole { get; set; }

        [Required(ErrorMessage = "Please select zone.")]
        public int inZoneId { get; set; }
        public int inStoreId { get; set; }
        public int inDivisionId { get; set; }

        [Required(ErrorMessage = "Please select department.")]
        public int inDepartmentId { get; set; }

        [Required(ErrorMessage = "Please select designation.")]
        public int inDesignationId { get; set; }

        [Required(ErrorMessage = "Please enter firstname.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "First name cannot be blank or whitespace")]
        public string stFirstName {get;set;}

        [Required(ErrorMessage = "Please enter lastname.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Last name cannot be blank or whitespace")]
        public string stLastName  {get;set;}

        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(CommonFunctions.gsEmailValidationRegex, ErrorMessage = "Invalid email address.")]
        public string stEmail     {get;set;}

        [Required(ErrorMessage = "Please enter mobile.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Mobile cannot be blank or whitespace")]
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
