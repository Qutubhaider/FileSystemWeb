using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileSystemBAL.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        private readonly static int miPageSize = 10;

        public RoomController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Room/RoomList.cshtml");
        }

        public IActionResult Detail()
        {
            return View("~/Areas/Admin/Views/Room/RoomDetail.cshtml");
        }
    }
}

