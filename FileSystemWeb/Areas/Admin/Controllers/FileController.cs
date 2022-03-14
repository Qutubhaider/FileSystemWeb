using FileSystemBAL.FIle.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Models;
using FileSystemUtility.Service.PaginationService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public FileController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/File/FileList.cshtml");
        }
        public IActionResult Detail(Guid id)
        {
            FileDetail loFileDetail = new FileDetail();
            if (id != Guid.Empty)
            {
                loFileDetail =  moUnitOfWork.FileRepository.GetFileDetail(id);
            }
            //sloState.StateList = moUnitOfWork.StateRepository.GetStateDropDown();
            return View("~/Areas/Admin/Views/File/FileDetail.cshtml", loFileDetail);
        }
        public IActionResult GetFileList(string fsFileName, int? Status, int? sort_column, string sort_order, int? pg, int? size)
        {
            StringBuilder lolog = new StringBuilder();
            try
            {
                /*lolog.AppendLine("DeskName : " + DeskName);
                lolog.AppendLine("Status : " + Status);
                lolog.AppendLine("Sort Column : " + sort_column);
                lolog.AppendLine("Sort Order : " + sort_order);
                lolog.AppendLine("Page No : " + pg);
                lolog.AppendLine("Page Size : " + size);
*/
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

                List<FileListResult> loFileListResults = new List<FileListResult>();
                loFileListResults = moUnitOfWork.FileRepository.GetFileList(fsFileName == null ? fsFileName : fsFileName.Trim(), sort_column, sort_order, pg.Value, size.Value);
                dynamic loModel = new ExpandoObject();
                loModel.GetFileList = loFileListResults;
                if (loFileListResults.Count > 0)
                {
                    liTotalRecords = loFileListResults[0].inRecordCount;
                    liStartIndex = loFileListResults[0].inRownumber;
                    liEndIndex = loFileListResults[loFileListResults.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/Admin/Views/Room/_RoomListData.cshtml", loModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }
        public IActionResult GetDivisionDropDown(int fiZoneId)
        {
            List<Select2> DivisionDropDown = moUnitOfWork.DivisionRepository.GetDivisionDropDown(fiZoneId);
            return Json(new { data = DivisionDropDown });

        }

    }
}
