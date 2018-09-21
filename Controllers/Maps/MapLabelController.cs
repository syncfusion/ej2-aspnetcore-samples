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
        public IActionResult MapLabel()
        {
            ViewBag.usmap = getusMap();
            return View();
        }
        public object getusMap()
        {
            string usmap = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/usMap.js");
            return JsonConvert.DeserializeObject(usmap);
        }
    }
}