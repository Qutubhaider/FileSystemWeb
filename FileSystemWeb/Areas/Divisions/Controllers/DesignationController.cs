﻿using FileSystemBAL.Designation.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Service.PaginationService;
using FileSystemUtility.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Areas.Divisions.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("Divisions")]
    public class DesignationController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;
        public DesignationController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }
            public IActionResult Index()
        {
            return View("~/Areas/Divisions/Views/Designation/DesignationList.cshtml");
        }
        public IActionResult Detail(Guid id)
        {
            Designation loDesignation = new Designation();
            if(id!=Guid.Empty)
            {
                loDesignation = moUnitOfWork.DesignationRepository.GetDesignation(id);
            }
            loDesignation.DepartmentList = moUnitOfWork.DepartmentRepository.GetDepartmentDropDown();
            return View("~/Areas/Divisions/Views/Designation/DesignationDetail.cshtml", loDesignation);
        }
        public IActionResult SaveDesignation(Designation foDesignation)
        {
            try
            {
                int liSuccess = 0;
                int liUserId = Convert.ToInt32(User.FindFirst(SessionConstant.Id).Value.ToString()); //User.FindFirst(SessionConstant)
                if (foDesignation != null)
                {
                    moUnitOfWork.DesignationRepository.SaveDesignation(foDesignation, liUserId, out liSuccess);
                    if (liSuccess == (int)CommonFunctions.ActionResponse.Add)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Add;
                        TempData["Message"] = string.Format(AlertMessage.RecordAdded, "Designation");
                        return RedirectToAction("Index");
                    }
                    else if (liSuccess == (int)CommonFunctions.ActionResponse.Update)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Update;
                        TempData["Message"] = string.Format(AlertMessage.RecordUpdated, "Designation");
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving designation");
                        return RedirectToAction("Index");
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving designation");
                return RedirectToAction("Index");
            }
        }
        public IActionResult GetDesignationList(string DesignationName, int? sort_column, string sort_order, int? pg, int? size)
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

                List<DesignationListResult> loDesignationResult = new List<DesignationListResult>();
                loDesignationResult = moUnitOfWork.DesignationRepository.GetDesignationList(DesignationName == null ? DesignationName : DesignationName.Trim(), sort_column, sort_order, pg.Value, size.Value,Convert.ToInt32(User.FindFirst(SessionConstant.Id).Value.ToString()));
                dynamic loModel = new ExpandoObject();
                loModel.GetDesignationList = loDesignationResult;
                if (loDesignationResult.Count > 0)
                {
                    liTotalRecords = loDesignationResult[0].inRecordCount;
                    liStartIndex = loDesignationResult[0].inRownumber;
                    liEndIndex = loDesignationResult[loDesignationResult.Count - 1].inRownumber;
                }
                loModel.Pagination = PaginationService.getPagination(liTotalRecords, pg.Value, size.Value, liStartIndex, liEndIndex);
                return PartialView("~/Areas/Divisions/Views/Designation/_DesignationListData.cshtml", loModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}
