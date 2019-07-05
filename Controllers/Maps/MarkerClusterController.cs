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
        public IActionResult MarkerCluster()
        {
            ViewBag.world = WorldMap();
            ViewBag.marker =  Clustersettings();
            return View();
        }
        public object WorldMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object Clustersettings()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/markercluster.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}