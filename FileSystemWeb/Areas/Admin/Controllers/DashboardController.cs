using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
