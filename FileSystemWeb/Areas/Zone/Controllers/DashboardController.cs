using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Zone.Controllers
{
    [Area("Zone")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Zone/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
