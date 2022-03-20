using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FileSystemUtility.Utilities.CommonConstant;

namespace DmfWeb.Areas.Stores.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, Roles = ((string)RoleConstants.StoreOP))]
    [Area("Stores")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Stores/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
