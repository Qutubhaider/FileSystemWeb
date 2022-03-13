﻿using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.Shelve.Models;
using FileSystemUtility.Models;
using FileSystemUtility.Service.PaginationService;
using FileSystemUtility.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShelvesController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public ShelvesController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Shelves/ShelvesList.cshtml");
        }

        public IActionResult Detail(Guid id)
        {
            Shelve loShelve = new Shelve();
            if (id != Guid.Empty)
            {
                loShelve = moUnitOfWork.ShelveRepository.GetShelveDetail(id);
            }
            loShelve.ZoneList = moUnitOfWork.ZoneRepository.GetZoneDropDown();
            loShelve.DepartmentList = moUnitOfWork.DepartmentRepository.GetDepartmentDropDown();
            loShelve.StoreList = moUnitOfWork.StoreRepository.GetStoreDropDown();
            loShelve.RoomList = moUnitOfWork.RoomRepository.GetRoomDropDown();
            return View("~/Areas/Admin/Views/Shelves/ShelvesDetail.cshtml", loShelve);
        }
        public IActionResult SaveShelve(Shelve foShelve)
        {
            try
            {
                int liSuccess = 0;
                int liUserId = 1; //User.FindFirst(SessionConstant)
                if (foShelve != null)
                {
                    moUnitOfWork.ShelveRepository.SaveShelve(foShelve, liUserId, out liSuccess);
                    if (liSuccess == (int)CommonFunctions.ActionResponse.Add)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Add;
                        TempData["Message"] = string.Format(AlertMessage.RecordAdded, "Shelve");
                        return RedirectToAction("Index");
                    }
                    else if (liSuccess == (int)CommonFunctions.ActionResponse.Update)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Update;
                        TempData["Message"] = string.Format(AlertMessage.RecordUpdated, "Shelve");
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving shelve");
                        return RedirectToAction("Index");
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving shelve");
                return RedirectToAction("Index");
            }
        }
        public IActionResult GetShelveList(string ShelveNumber, int? Status, int? sort_column, string sort_order, int? pg, int? size)
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

                List<ShelveListResult> loShelveListResults = new List<ShelveListResult>();
                loShelveListResults = moUnitOfWork.ShelveRepository.GetShelveList(ShelveNumber == null ? ShelveNumber : ShelveNumber.Trim(), sort_column, sort_order, pg.Value, size.Value);
                dynamic loModel = new ExpandoObject();
                loModel.GetShelveList = loShelveListResults;
                if (loShelveListResults.Count > 0)
                {
                    liTotalRecords = loShelveListResults[0].inRecordCount;
                    liStartIndex = loShelveListResults[0].inRownumber;
                    liEndIndex = loShelveListResults[loShelveListResults.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/Admin/Views/Shelves/_ShelvesListData.cshtml", loModel);
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
