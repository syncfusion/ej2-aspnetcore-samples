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
        public IActionResult SalesMap()
        {
            ViewBag.world = SaleWorldMap();
            ViewBag.marker =  productWorth();
            return View();
        }
        public object SaleWorldMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object productWorth()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/ProductWorth.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}