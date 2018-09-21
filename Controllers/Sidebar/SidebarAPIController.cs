using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SidebarController : Controller
    {
        public IActionResult SidebarAPI()
        {
            ViewBag.data = new string[] { "Over", "Push", "Slide" , "Auto" };
            return View();
        }
    }
}