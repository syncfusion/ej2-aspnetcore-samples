using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EJ2CoreSampleBrowser.Controllers.Maps
{
    public partial class MapsController: Controller
    {
        public IActionResult Curvedlines()
        {
            ViewBag.markers = GetCurvedMarkers();
            ViewBag.mapdata = GetWroldMap();
            ViewBag.filghtdata = GetFlightRoutes();
            return View();
        }
        public object GetCurvedMarkers()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/curvedlinemarkers.js");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetFlightRoutes()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/flightroutes.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}