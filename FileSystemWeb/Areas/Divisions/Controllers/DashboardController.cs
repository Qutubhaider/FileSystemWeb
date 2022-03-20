using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FileSystemUtility.Utilities.CommonConstant;

namespace DmfWeb.Areas.Divisions.Controllers
{
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, Roles = ((string)RoleConstants.DivisionAdmin))]
    [Area("Divisions")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Divisions/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
