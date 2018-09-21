using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Dialog
{
    public partial class DialogController : Controller
    {
        public IActionResult AjaxContent()
        {
            ViewBag.ajaxbutton = new
            {
                content = "More Details",
                isPrimary = true
            };
            return View();
        }
    }
}