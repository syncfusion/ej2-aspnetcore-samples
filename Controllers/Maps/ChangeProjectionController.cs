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
        public IActionResult ChangeProjection()
        {
            ViewBag.uno = unocountries();
            ViewBag.mapdata = GetWroldMap();
            return View();
        }
        public object unocountries()
        {
            string allText = System.IO.File.ReadAllText("./wwwroot/scripts/MapsData/unocontries.js");
            return JsonConvert.DeserializeObject(allText);
        }
    }
}