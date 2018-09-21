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
        public IActionResult Default()
        {
            ViewBag.dataSource = getDataSource();
            ViewBag.mapdata = GetWroldMap();
            return View();
        }
        public object getDataSource()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/salescontinent.js");
            return JsonConvert.DeserializeObject(allText);
        }
        public object GetWroldMap()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/WorldMap.json");
            return JsonConvert.DeserializeObject(allText);
        }

    }
}