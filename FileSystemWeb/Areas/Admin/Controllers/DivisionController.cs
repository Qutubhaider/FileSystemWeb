using FileSystemBAL.Division.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DmfWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DivisionController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;
        public DivisionController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Divistion/DivistionList.cshtml");
        }
        public IActionResult Detail(Guid id)
        {
            Division loDivision = new Division();
            if (id != Guid.Empty)
            {
                loDivision = moUnitOfWork.DivisionRepository.GetDivision(id);
            }
            loDivision.ZoneList = moUnitOfWork.ZoneRepository.GetZoneDropDown();
            return View("~/Areas/Admin/Views/Divistion/DivisionDetail.cshtml",loDivision);
        }
        public IActionResult SaveDivision(Division foDivision)
        {
            try
            {
                int liSuccess = 0;
                int liUserId = 1; //User.FindFirst(SessionConstant)
                if (foDivision != null)
                {
                    moUnitOfWork.DivisionRepository.SaveDivision(foDivision, liUserId, out liSuccess);
                    if (liSuccess == (int)CommonFunctions.ActionResponse.Add)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Add;
                        TempData["Message"] = string.Format(AlertMessage.RecordAdded, "Division");
                        return RedirectToAction("Index");
                    }
                    else if (liSuccess == (int)CommonFunctions.ActionResponse.Update)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Update;
                        TempData["Message"] = string.Format(AlertMessage.RecordUpdated, "Division");
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving division");
                        return RedirectToAction("Index");
                    }

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving division");
                return RedirectToAction("Index");
            }
        }
    }
}
