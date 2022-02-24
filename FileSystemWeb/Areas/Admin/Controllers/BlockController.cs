using Microsoft.AspNetCore.Mvc;

namespace DmfWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlockController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Block/BlockList.cshtml");
        }
    }
}
