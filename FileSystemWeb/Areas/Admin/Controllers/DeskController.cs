using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeskController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Desk/DeskDetail.cshtml");
        }
        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Desk/DeskList.cshtml");
        }
    }
}
