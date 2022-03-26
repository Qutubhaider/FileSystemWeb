using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.DeskOP.Controllers
{
    public class CaseController : Controller
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [Area("DeskOP")]
        public class UserController : Controller
        {
            public IActionResult Index()
            {
                return View("~/Areas/DeskOP/Views/Case/CaseList.cshtml");
            }
            public IActionResult Detail()
            {
                return View("~/Areas/DeskOP/Views/Case/CaseDetail.cshtml");
            }
        }
    }
}
