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
        public IActionResult ResponsiveModes()
        {
            ViewBag.positionData = new string[] { "Scrollable", "Popup" };
            ViewBag.orientationData = new string[] { "Top", "Bottom", "Left", "Right" };

            ViewBag.headerText0 = new TabHeader { Text = "HTML" };
            ViewBag.headerText1 = new TabHeader { Text = "C-Sharp(C#)" };
            ViewBag.headerText2 = new TabHeader { Text = "Java" };
            ViewBag.headerText3 = new TabHeader { Text = "VB.NET" };
            ViewBag.headerText4 = new TabHeader { Text = "Xamarin" };
            ViewBag.headerText5 = new TabHeader { Text = "ASP.NET" };
            ViewBag.headerText6 = new TabHeader { Text = "ASP.NET MVC" };
            ViewBag.headerText7 = new TabHeader { Text = "JavaScript" };
            return View();
        }
    }
}
