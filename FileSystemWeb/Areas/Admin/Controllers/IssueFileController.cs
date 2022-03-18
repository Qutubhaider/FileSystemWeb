using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileSystemWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IssueFileController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/IssueFile/IssueFileList.cshtml");
        }

        public IActionResult Detail()
        {
            return View("~/Areas/Admin/Views/IssueFile/IssueFile.cshtml");
        }
    }
}

