using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Stores.Controllers
{
    [Area("Stores")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Stores/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
