using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Dialog
{
    public partial class DialogController : Controller
    {
        public IActionResult CustomDialogs()
        {
            ViewBag.alertbutton = new
            {
                content = "Dismiss",
                isPrimary = true
            };
            ViewBag.confirmbutton = new
            {
                content = "Yes",
                isPrimary = true
            };
            ViewBag.confirmbutton1 = new
            {
                content = "No",
            };
            ViewBag.promptbutton = new
            {
                content = "Connect",
                isPrimary = true
            };
            ViewBag.promptbutton1 = new
            {
                content = "Cancel",
            };
            return View();
        }
    }
}