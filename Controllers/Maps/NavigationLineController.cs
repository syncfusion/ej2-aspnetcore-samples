using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.Maps
{
    public partial class MapsController : Controller
    {
        public IActionResult NavigationLine()
        {
            ViewBag.worldmap = GetWroldMap();
            ViewBag.navlines = getNavigationLines();
            return View();
        }
        public object getNavigationLines()
        {
            string text = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/navigationline.js");
            return JsonConvert.DeserializeObject(text);
        }
    }
}