using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.DeskAdmin.Controllers
{
    public class AssignFileController : Controller
    {
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [Area("DeskAdmin")]
        public IActionResult Index()
        {
            return View("~/Areas/DeskAdmin/Views/User/AssignFileList.cshtml");
        }
    }
}
