using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Dialog
{
    public partial class DialogController : Controller
    {
        public IActionResult MultipleDialogs()
        {
            ViewBag.defaultbutton = new
            {
                content = "Next",
                isPrimary = true
            };
            ViewBag.defaultbutton1 = new
            {
                content = "Close",
                isPrimary = true
            };
            return View();
        }
    }
}