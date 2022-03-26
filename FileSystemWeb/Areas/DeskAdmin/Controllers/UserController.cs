using FileSystemBAL.Repository.IRepository;
using FileSystemBAL.User.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using static FileSystemUtility.Utilities.CommonConstant;

namespace FileSystemWeb.Areas.DeskAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskAdmin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;
        public UserController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }
        public IActionResult Index()
        {
            return View("~/Areas/DeskAdmin/Views/User/UserList.cshtml");
        }

        public IActionResult Detail(Guid id)
        {
            UserProfile loUserProfile = new UserProfile();
            if (id != Guid.Empty)
            {
                loUserProfile = moUnitOfWork.UserRepository.GetUserDetail(id);
            }
            //loUserProfile.ZoneList = moUnitOfWork.ZoneRepository.GetZoneDropDown();
            //loUserProfile.DepartmentList = moUnitOfWork.DepartmentRepository.GetDepartmentDropDown();
            loUserProfile.inZoneId = Convert.ToInt32(User.FindFirst(SessionConstant.ZoneId).Value.ToString());
            loUserProfile.inDivisionId= Convert.ToInt32(User.FindFirst(SessionConstant.DivisionId).Value.ToString());
            return View("~/Areas/DeskAdmin/Views/User/UserDetail.cshtml",loUserProfile);
        }
    }
}
