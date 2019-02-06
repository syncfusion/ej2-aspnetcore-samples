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
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DefaultFunctionalities()
        {
            ViewBag.headerTextOne = new TabHeader { Text = "Twitter", IconCss = "e-twitter" };
            ViewBag.headerTextTwo = new TabHeader { Text = "Facebook", IconCss = "e-facebook" };
            ViewBag.headerTextThree = new TabHeader { Text = "Whatsapp", IconCss = "e-whatsapp" };
            return View();
        }
    }
}
