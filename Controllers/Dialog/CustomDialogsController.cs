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
                content = "DISMISS",
                isPrimary = true
            };
            ViewBag.confirmbutton = new
            {
                content = "YES",
                isPrimary = true
            };
            ViewBag.confirmbutton1 = new
            {
                content = "NO",
            };
            ViewBag.promptbutton = new
            {
                content = "CONNECT",
                isPrimary = true
            };
            ViewBag.promptbutton1 = new
            {
                content = "CANCEL",
            };
            return View();
        }
    }
}