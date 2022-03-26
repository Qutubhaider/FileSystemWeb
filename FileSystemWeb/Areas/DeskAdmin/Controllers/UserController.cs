using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileSystemWeb.Areas.DeskAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskAdmin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/DeskAdmin/Views/User/UserList.cshtml");
        }
    }
}
