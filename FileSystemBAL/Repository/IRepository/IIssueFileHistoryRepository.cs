﻿using FileSystemBAL.IssueFIleHistory;
using FileSystemBAL.IssueFIleHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository.IRepository
{
   public  interface IIssueFileHistoryRepository
    {
        void SaveIssueFile(IssueFile foIssueFile, int fiUserId, out int fiSuccess);
        IssueFile GetIssueFileDetail(Guid fuIssueFileId);
        //void DeleteAlmirah(Guid fuAmirahId, out int fiSuccess);
        List<IssueFileListResult> GetIssueFileList(string fsAlmirahNumber, int? fiSortColumn, string fsSortOrder, int? fiPageNo, int? fiPageSize);
        //List<Select2> GetADropDown(int fiRoomId);
    }
}