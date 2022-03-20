using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FileSystemUtility.Utilities.CommonConstant;

namespace DmfWeb.Areas.Admin.Controllers
{   
    [Area("Admin")]
    //[Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
