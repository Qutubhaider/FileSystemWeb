using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Departments.Controllers
{
    [Area("Departments")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Departments/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
