using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Store.Controllers
{
    [Area("Store")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Store/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
