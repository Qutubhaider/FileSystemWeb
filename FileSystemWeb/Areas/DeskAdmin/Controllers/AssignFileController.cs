using FileSystemBAL.IssueFIleHistory.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Service.PaginationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Areas.DeskAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskAdmin")]
    public class AssignFileController : Controller
    {
       
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public AssignFileController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }
        public IActionResult Index()
        {
            return View("~/Areas/DeskAdmin/Views/AssignFile/AssignFileList.cshtml");
        }

        public IActionResult GetIssueFileList(string fsFileName, int? Status, int? sort_column, string sort_order, int? pg, int? size)
        {
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

                List<IssueFileListResult> loIssueFileListResult = new List<IssueFileListResult>();
                loIssueFileListResult = moUnitOfWork.IssueFileHistoryRepository.GetIssueFileList(fsFileName == null ? fsFileName : fsFileName.Trim(), sort_column, sort_order, pg.Value, size.Value,null, Convert.ToInt32(User.FindFirst(SessionConstant.DepartmentId).Value.ToString()));
                dynamic loModel = new ExpandoObject();
                loModel.GetIssueFileList = loIssueFileListResult;
                if (loIssueFileListResult.Count > 0)
                {
                    liTotalRecords = loIssueFileListResult[0].inRecordCount;
                    liStartIndex = loIssueFileListResult[0].inRownumber;
                    liEndIndex = loIssueFileListResult[loIssueFileListResult.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/DeskAdmin/Views/AssignFile/_AssignFileList.cshtml", loModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public IActionResult AssignFileDetail(Guid? id)
        {
            return View("~/Areas/DeskAdmin/Views/AssignFile/AssignFileList.cshtml");
        }
    }
}
