using FileSystemBAL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShelvesController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public ShelvesController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Shelves/ShelvesList.cshtml");
        }

        public IActionResult Detail()
        {
            return View("~/Areas/Admin/Views/Shelves/ShelvesDetail.cshtml");
        }
    }
}
