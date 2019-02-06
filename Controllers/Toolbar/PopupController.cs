using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ToolbarController : Controller
    {
        public IActionResult Popup()
        {
            ViewBag.date = String.Format("{0:MMMM}", DateTime.Now).ToString() + " " + DateTime.Now.Year.ToString();
            return View();
        }
    }
}
