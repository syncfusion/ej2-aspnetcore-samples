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
        public IActionResult Marker()
        {
            ViewBag.mapdata = GetWroldMap();
            ViewBag.marker = getmarker();
            return View();
        }
        public object getmarker()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/markerlocation.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}