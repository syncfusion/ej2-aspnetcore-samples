using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Dialog
{
    public partial class DialogController : Controller
    {
        public IActionResult Animation()
        {
            ViewBag.defaultbutton = new
            {
                content = "Hide",
                isPrimary = true
            };
            return View();
        }
    }
}