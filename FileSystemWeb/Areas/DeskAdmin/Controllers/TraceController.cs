using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemWeb.Areas.DeskAdmin.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Area("DeskAdmin")]
    public class TraceController : Controller
    {
        public IActionResult TraceFile()
        {
            return View("~/Areas/DeskAdmin/Views/Trace/TraceFile.cshtml");
        }

        public IActionResult TraceCase()
        {
            return View("~/Areas/DeskAdmin/Views/Trace/TraceCase.cshtml");
        }
    }
}
