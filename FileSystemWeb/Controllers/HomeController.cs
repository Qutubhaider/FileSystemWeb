﻿using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.User.Models;
using FileSystemUtility.Utilities;
using FileSystemWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                            claims.Add(new Claim(SessionConstant.stUserName, UserDetail.stUsername));
                            claims.Add(new Claim(SessionConstant.unUserId, UserDetail.unUserId.ToString()));
                            claims.Add(new Claim(SessionConstant.RoleId, UserDetail.inRole.ToString()));
                            claims.Add(new Claim(ClaimTypes.Role, UserDetail.inRole.ToString()));
                            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24) });

                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
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
    }
}
