using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TabController : Controller
    {
        public IActionResult Rtl()
        {
            ViewBag.headerTextOne = new TabHeader { Text = "Twitter" };
            ViewBag.headerTextTwo = new TabHeader { Text = "Facebook" };
            ViewBag.headerTextThree = new TabHeader { Text = "Whatsapp" };
            return View();
        }
    }
}
