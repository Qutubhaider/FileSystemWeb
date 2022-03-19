﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemBAL.Room.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Models;
using FileSystemUtility.Service.PaginationService;
using FileSystemUtility.Utilities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileSystemWeb.Areas.Divisions.Controllers
{
    [Area("Divisions")]
    public class RoomController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public RoomController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Divisions/Views/Room/RoomList.cshtml");
        }

        public IActionResult Detail(Guid id)
        {
            Room loRoom = new Room();
            if (id != Guid.Empty)
            {
                loRoom = moUnitOfWork.RoomRepository.GetRoomDetail(id);
            }
            loRoom.ZoneList = moUnitOfWork.ZoneRepository.GetZoneDropDown();
            loRoom.DepartmentList = moUnitOfWork.DepartmentRepository.GetDepartmentDropDown();
            //loRoom.StoreList = moUnitOfWork.StoreRepository.GetStoreDropDown(); ;
            //return View("~/Areas/Admin/Views/Desk/DeskDetail.cshtml", loDesk);
            return View("~/Areas/Divisions/Views/Room/RoomDetail.cshtml", loRoom);
        }
        public IActionResult SaveRoom(Room foRoom)
        {
            try
            {
                int liSuccess = 0;
                int liUserId = 1; //User.FindFirst(SessionConstant)
                if (foRoom != null)
                {
                    moUnitOfWork.RoomRepository.SaveRoom(foRoom, liUserId, out liSuccess);
                    if (liSuccess == (int)CommonFunctions.ActionResponse.Add)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Add;
                        TempData["Message"] = string.Format(AlertMessage.RecordAdded, "Room");
                        return RedirectToAction("Index");
                    }
                    else if (liSuccess == (int)CommonFunctions.ActionResponse.Update)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Update;
                        TempData["Message"] = string.Format(AlertMessage.RecordUpdated, "Room");
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving room");
                        return RedirectToAction("Index");
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving room");
                return RedirectToAction("Index");
            }
        }

        public IActionResult GetRoomList(string RoomNumber, int? Status, int? sort_column, string sort_order, int? pg, int? size)
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

                List<RoomListResult> loRoomListResults = new List<RoomListResult>();
                loRoomListResults = moUnitOfWork.RoomRepository.GetRoomList(RoomNumber == null ? RoomNumber : RoomNumber.Trim(), sort_column, sort_order, pg.Value, size.Value);
                dynamic loModel = new ExpandoObject();
                loModel.GetRoomList = loRoomListResults;
                if (loRoomListResults.Count > 0)
                {
                    liTotalRecords = loRoomListResults[0].inRecordCount;
                    liStartIndex = loRoomListResults[0].inRownumber;
                    liEndIndex = loRoomListResults[loRoomListResults.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/Divisions/Views/Room/_RoomListData.cshtml", loModel);
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
        public IActionResult GetStoreDropdown(int fiDivisionId)
        {
            List<Select2> StoreDropDown = moUnitOfWork.StoreRepository.GetStoreDropDown(fiDivisionId);
            return Json(new { data = StoreDropDown });

        }
    }
}

