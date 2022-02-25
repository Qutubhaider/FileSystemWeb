using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DivisionController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Divistion/DivistionList.cshtml");
        }
        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Divistion/AddDivision.cshtml");
        }
    }
}
