using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DesignationController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Designation/DesignationList.cshtml");
        }
        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Designation/DesignationDetail.cshtml");
        }
    }
}
