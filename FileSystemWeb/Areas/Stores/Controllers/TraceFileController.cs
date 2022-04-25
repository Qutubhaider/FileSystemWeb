﻿using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.Trace;
using FileSystemBAL.Trace.Models;
using FileSystemUtility.Service.PaginationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Areas.Stores.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Stores")]
    public class TraceFileController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public TraceFileController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Stores/Views/TraceFile/TraceFile.cshtml");
        }

        public IActionResult GetTraceFileList(int? sort_column, string sort_order, int? pg, int? size)
        {
            StringBuilder lolog = new StringBuilder();
            try
            {
                string lsSearch = string.Empty;
                int liTotalRecords = 0, liStartIndex = 0, liEndIndex = 0;
                if (sort_column == 0 || sort_column == null)
                    sort_column = 1;
                if (string.IsNullOrEmpty(sort_order) || sort_order == "desc")
                {
                    sort_order = "desc";
                    ViewData["sortorder"] = "asc";
                }
                else
                {
                    ViewData["sortorder"] = "desc";
                }
                if (pg == null || pg <= 0)
                    pg = 1;
                if (size == null || size.Value <= 0)
                    size = miPageSize;

                List<TraceFileResults> loIssueFileListResult = moUnitOfWork.FileRepository.GetTraceFileList(null,Convert.ToInt32(User.FindFirst(SessionConstant.StoreId).Value.ToString()),null,null,null,null,null, sort_column, sort_order, pg.Value, size.Value);
                dynamic loModel = new ExpandoObject();
                loModel.GetTraceFileList = loIssueFileListResult;
                if (loIssueFileListResult.Count > 0)
                {
                    liTotalRecords = loIssueFileListResult[0].inRecordCount;
                    liStartIndex = loIssueFileListResult[0].inRownumber;
                    liEndIndex = loIssueFileListResult[loIssueFileListResult.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/Stores/Views/TraceFile/_TraceFile.cshtml", loModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
