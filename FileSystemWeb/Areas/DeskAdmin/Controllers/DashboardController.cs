using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FileSystemUtility.Utilities.CommonConstant;

namespace DmfWeb.DeskAdmin.Stores.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/DeskAdmin/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
