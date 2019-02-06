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
        public IActionResult MapWithSlider()
        {
           ViewBag.MapData =  this.GetNorthAmerica();
            ViewBag.dataSource = GetPopulationGrowthData();
            return View();
        }
        public object GetPopulationGrowthData()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/PopulationGrowth.json");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}