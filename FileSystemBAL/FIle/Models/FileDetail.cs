using FileSystemUtility.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.FIle.Models
{
    public class FileDetail
    {
        public int inStoreFileDetail  {get;set;}
        public Guid unStoreFileDetail { get; set; }
        public int inStoreId          {get;set;}
        public int inUserId           {get;set;}
        public int inZoneId           {get;set;}
        public int inDivisionId       {get;set;}
        public int inDepartmentId     {get;set;}
        public int inRoomId           {get;set;}
        public int inAlmirahId        {get;set;}
        public int inShelvesId        {get;set;}
        public string stFileName      {get;set;}
        public string stEmployeeName  {get;set;}
        public string stPPONumber     {get;set;}
        public string stPFNumber      {get;set;}
        public string stEmployeeNumber{get;set;}
        public string stMobile        {get;set;}
        public int inStatus { get; set; }
        [NotMapped]
        public List<Select2> ZoneList { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
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
    }
}
