using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Users.Controllers
{
    [Area("Users")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Users/Views/Dashboard/Dashboard.cshtml");
        }
    }
}
