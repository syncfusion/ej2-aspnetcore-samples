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
        public IActionResult Legend()
        {
            ViewBag.mapdata = GetWroldMap();
            ViewBag.population = getPopulation();
            return View();
        }
        public object getPopulation() {
            string text = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/populationdensity.js");
            return JsonConvert.DeserializeObject(text);
        }
    }
}