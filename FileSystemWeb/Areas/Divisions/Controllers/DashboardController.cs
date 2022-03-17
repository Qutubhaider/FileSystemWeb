using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Divisions.Controllers
{
    [Area("Divisions")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Divisions/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
