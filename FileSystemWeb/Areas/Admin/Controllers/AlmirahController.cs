using FileSystemBAL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlmirahController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public AlmirahController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Almirah/AlmirahList.cshtml");
        }

        public IActionResult Detail()
        {
            return View("~/Areas/Admin/Views/Almirah/AlmirahDetail.cshtml");
        }
    }
}
