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
        public IActionResult ColorMapping()
        {
            ViewBag.mapdata = this.getusMap();
            ViewBag.dataSource = GetColorMappingData();
            return View();
        }

        public object GetColorMappingData()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/ColorMapping.json");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}