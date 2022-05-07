﻿using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.User.Models;
using FileSystemUtility.Models;
using FileSystemUtility.Utilities;
using FileSystemWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork moUnitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork foUnitOfWork)
        {
            _logger = logger;
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            LoginVM loLoginVM = new LoginVM();
            return View("~/Views/Home/Login.cshtml", loLoginVM);
        }

        public IActionResult SignUp()
        {
            UserProfile loUserProfile = new UserProfile();          
            loUserProfile.ZoneList = moUnitOfWork.ZoneRepository.GetZoneDropDown();
            loUserProfile.DepartmentList = moUnitOfWork.DepartmentRepository.GetDepartmentDropDown();
            return View("~/Views/Home/SignUp.cshtml", loUserProfile);
        }

        public IActionResult GetDesignationDropDown(int fiDepartmentId)
        {
            List<Select2> DesignationDropDown = moUnitOfWork.DesignationRepository.GetDesignationDropDown(fiDepartmentId);
            return Json(new { data = DesignationDropDown });
        }

        public IActionResult GetDivisionDropDown(int fiZoneId)
        {
            List<Select2> DivisionDropDown = moUnitOfWork.DivisionRepository.GetDivisionDropDown(fiZoneId);
            return Json(new { data = DivisionDropDown });
        }
        public IActionResult GetDeskDropdown(int fiDivisionId)
        {
            List<Select2> DeskDropDown = moUnitOfWork.DeskRepository.GetDeskDropDown(fiDivisionId);
            return Json(new { data = DeskDropDown });
        }
        public IActionResult GetStoreDropdown(int fiDivisionId)
        {
            List<Select2> StoreDropDown = moUnitOfWork.StoreRepository.GetStoreDropDown(fiDivisionId);
            return Json(new { data = StoreDropDown });

        }
        public IActionResult AuthenticateUser(LoginVM foLoginVM)
        {
            try
            {
                UserEmailResult UserDetail = moUnitOfWork.UserRepository.GetUserByEmail(foLoginVM.stEmail);
                if (UserDetail != null)
                {
                    if (foLoginVM.stPassword == UserDetail.stPassword)
                    {
                        if (UserDetail.inStatus == (int)CommonFunctions.UserStatus.InActive)
                        {
                            TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                            TempData["Message"] = string.Format(AlertMessage.UserInactive);
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            var claims = new List<Claim>();
                            claims.Add(new Claim(SessionConstant.stEmail, UserDetail.stEmail));
                            claims.Add(new Claim(SessionConstant.Id, UserDetail.inUserId.ToString()));
                            claims.Add(new Claim(SessionConstant.stUserName, UserDetail.stUsername));
                            claims.Add(new Claim(SessionConstant.unUserId, UserDetail.unUserId.ToString()));
                            claims.Add(new Claim(SessionConstant.RoleId, UserDetail.inRole.ToString()));
                            claims.Add(new Claim(SessionConstant.ZoneId, UserDetail.inZoneId.ToString()));
                            claims.Add(new Claim(SessionConstant.DesignationId, UserDetail.inDesignationId.ToString()));
                            claims.Add(new Claim(SessionConstant.DivisionId, UserDetail.inDivisionId.ToString()));
                            claims.Add(new Claim(SessionConstant.DeskId, UserDetail.inDeskId.ToString()));
                            claims.Add(new Claim(SessionConstant.DepartmentId, UserDetail.inDepartmentId.ToString()));
                            claims.Add(new Claim(SessionConstant.StoreId, UserDetail.inStoreId.ToString()));
                            claims.Add(new Claim(SessionConstant.DepartmentName, UserDetail.stDepartmentName.ToString()));
                            claims.Add(new Claim(SessionConstant.Name, UserDetail.stFirstName.ToString()));
                            claims.Add(new Claim(SessionConstant.ZoneName, UserDetail.stZoneName.ToString()));
                            claims.Add(new Claim(SessionConstant.DivisionName, UserDetail.stDivisionName.ToString()));
                            claims.Add(new Claim(ClaimTypes.Role, UserDetail.inRole.ToString()));
                            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24) });

                            if (UserDetail.inRole == (int)UserType.Admin)
                                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                            else if (UserDetail.inRole == (int)UserType.DivisionAdmin)
                                return RedirectToAction("Index", "Dashboard", new { area = "Divisions" });
                            else if (UserDetail.inRole == (int)UserType.DepartmentAdmin)
                                return RedirectToAction("Index", "Dashboard", new { area = "Departments" });
                            else if (UserDetail.inRole == (int)UserType.StoreOP)
                                return RedirectToAction("Index", "Dashboard", new { area = "Stores" });
                            else if (UserDetail.inRole == (int)UserType.DeskAdmin)
                                return RedirectToAction("Index", "Dashboard", new { area = "DeskAdmin" });
                            else
                                return RedirectToAction("Index", "Dashboard", new { area = "DeskOP" });

                           
                        }

                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.CredentialMisMatch);
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                    TempData["Message"] = string.Format(AlertMessage.UserNotFound);
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "login");
                return RedirectToAction("Login");
            }
        }

        [AllowAnonymous]
        //[HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Error");
            }
            return RedirectToAction("Login");
        }
    }
}
