using FileSystemBAL.Case.Models;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Service.PaginationService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Areas.DeskOP.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskOP")]
    public class CaseController : Controller
    {

            private readonly IUnitOfWork moUnitOfWork;
            private readonly static int miPageSize = 10;

            public CaseController(IUnitOfWork foUnitOfWork)
            {
                moUnitOfWork = foUnitOfWork;
            }
            public IActionResult Index()
            {
                return View("~/Areas/DeskOP/Views/Case/CaseList.cshtml");
            }

            
            public IActionResult Detail(Guid fuCaseId)
            {
               
                return View("~/Areas/DeskOP/Views/Case/CaseDetail.cshtml");
            }
    }
}
