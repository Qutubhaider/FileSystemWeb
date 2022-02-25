using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Department/DepartmentList.cshtml");
        }
        public IActionResult Create()
        {
            return View("~/Areas/Admin/Views/Department/AddDepartment.cshtml");
        }
    }
}
