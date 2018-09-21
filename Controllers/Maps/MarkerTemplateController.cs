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
        public IActionResult MarkerTemplate()
        {
            ViewBag.australia = AustraliaMap();
            return View();
        }
        public object AustraliaMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/australia.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}