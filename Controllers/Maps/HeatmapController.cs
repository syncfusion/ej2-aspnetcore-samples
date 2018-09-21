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
        public IActionResult Heatmap()
        {
            ViewBag.population = GetIndianPopulation();
            ViewBag.india = GetIndiaData();
            return View();
        }
        public object GetIndiaData()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/india.json");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetIndianPopulation()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/indianpopulation.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}