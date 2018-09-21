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
        public IActionResult Print()
        {
            ViewBag.mapdata = getusMap();
            ViewBag.datasource = this.getPopulationDataSource();
            return View();
        }

        public object getPopulationDataSource()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usPopulation.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}